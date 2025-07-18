﻿using SSC.Chat;
using SSC.Structs.Gemini;
using SSC.Structs.Gemini.FunctionTypes;
using SSC.Structs.Gemini.FunctionTypes.Other;
using SSC.Structs.Gemini.FunctionTypes.Speedrun;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI;
using SuiBotAI.Components;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuiBot_TwitchSocket.API.EventSub.ES_ChannelPoints;
using static SuiBotAI.Components.SuiBotAIProcessor;

namespace SSC
{
	public class GeminiAI
	{
		private SuiBotAIProcessor m_Processor;
		public bool IsRegistered { get; private set; }
		public GeminiContent StreamerContent = new GeminiContent();
		public Dictionary<string, GeminiContent> UserContents = new Dictionary<string, GeminiContent>();
		public Dictionary<string, DateTime> Cooldowns = new Dictionary<string, DateTime>();
		private Tuple<ES_AdBreakBeginNotification, GeminiContent> m_TemporaryMemoryForAdNotification;
		private List<string> AvailableEmotes;

		internal bool IsConfigured()
		{
			var aiConfig = AIConfig.GetInstance();

			if (string.IsNullOrEmpty(aiConfig.ApiKey))
			{
				MainForm.Instance.ThreadSafeAddPreviewText($"Can't setup AI - no {nameof(aiConfig.ApiKey)} provided. This might be OK?", LineType.GeminiAI);
				return false;
			}

			if (string.IsNullOrEmpty(aiConfig.TwitchUsername))
			{
				MainForm.Instance.ThreadSafeAddPreviewText($"Can't setup AI - no streamer username provided", LineType.GeminiAI);
				return false;
			}

			if (string.IsNullOrEmpty(aiConfig.TwitchAwardID))
			{
				MainForm.Instance.ThreadSafeAddPreviewText($"Can't setup AI - no {nameof(aiConfig.TwitchAwardID)} set up.", LineType.GeminiAI);
				return false;
			}

			var path = AIConfig.GetAIHistoryPath(aiConfig.TwitchUsername);
			StreamerContent = XML_Utils.Load(path, new GeminiContent()
			{
				contents = new List<GeminiMessage>(),
				generationConfig = new GeminiContent.GenerationConfig(),
				safetySettings = null,
			});
			m_Processor = new SuiBotAIProcessor(aiConfig.ApiKey, aiConfig.Model);

			return true;
		}

		public void Register()
		{
			IsRegistered = true;
			MainForm.Instance.TwitchEvents.OnChannelPointsRedeem += PointsRedeem;
			MainForm.Instance.TwitchEvents.OnAdBreakStarted += GetResponseAdBreakStarted;
			MainForm.Instance.TwitchEvents.OnAdBreakFinished += GetResponseAdBreakFinished;
			MainForm.Instance.TwitchEvents.OnAdPrerollsActive += GetResponsePreRollsActivated;
			MainForm.Instance.TwitchEvents.OnChannelRaid += GetResponseRaid;
		}

		public void Unregister()
		{
			IsRegistered = false;
		}

		public void PointsRedeem(ES_ChannelPointRedeemRequest request)
		{
			if (request.state != RedemptionStates.UNFULFILLED)
				return;
			var rewardID = AIConfig.GetInstance().TwitchAwardID;
			if (string.IsNullOrEmpty(rewardID))
				return;
			if (request.reward.id != rewardID)
				return;

			Task.Run(async () =>
			{
				await GetResponse(request);
			});
		}

		private async Task GetResponse(ES_ChannelPointRedeemRequest request)
		{
			ChatBot bot = MainForm.Instance.TwitchBot;

			try
			{
				GeminiContent content = null;
				AIConfig aiConfig = AIConfig.GetInstance();
				ChannelInstance channelInstance = bot?.ChannelInstance;
				if (bot == null || bot.IsDisposed || channelInstance == null)
				{
					Logger.AddLine("Either bot or channel were already disposed.");
					return;
				}

				int tokenLimit = 1000;

				bool isChannelOwner = request.user_login == channelInstance.Channel;
				string path;
				GeminiMessage instructions = null;
				if (isChannelOwner)
				{
					path = AIConfig.GetAIHistoryPath(aiConfig.TwitchUsername);
					content = StreamerContent;

					tokenLimit = aiConfig.TokenLimit_Streamer;
					content.safetySettings = aiConfig.GetSafetySettingsStreamer();
					instructions = aiConfig.GetInstruction(request.user_name, true, true);
					content.generationConfig.temperature = aiConfig.Temperature_Streamer;
					content.tools = new List<GeminiTools>()
					{
						new GeminiTools(new SpeedrunWRCall(),
						new SpeedrunPBCall(),
						new OpenWeatherCall(),
						new PlaySoundCall(),
						new CurrentDateTimeCall())
					};
				}
				else
				{
					path = AIConfig.GetAIHistoryPath(request.user_id);

					if (!UserContents.TryGetValue(request.user_id, out content))
					{
						if (File.Exists(path))
						{
							content = XML_Utils.Load(path, new GeminiContent()
							{
								contents = new List<GeminiMessage>(),
								generationConfig = new GeminiContent.GenerationConfig(),
							});
						}
						else
						{
							content = new GeminiContent()
							{
								contents = new List<GeminiMessage>(),
								generationConfig = new GeminiContent.GenerationConfig(),
							};
						}

						UserContents.Add(request.user_id, content);
					}

					tokenLimit = aiConfig.TokenLimit_User;
					GeminiCharacterOverride overrides = GeminiCharacterOverride.GetOverride(GeminiCharacterOverride.GetOverridePath(request.user_login));
					if (overrides != null)
					{
						//content.systemInstruction = 
						content.safetySettings = overrides.GetSafetyOverrides();
						instructions = overrides.GetFullInstruction(aiConfig);
					}
					else
					{
						content.safetySettings = aiConfig.GetSafetySettingsGeneral();
						instructions = aiConfig.GetInstruction(request.user_name, false, channelInstance.StreamStatus?.IsOnline ?? false);
					}
					content.generationConfig.temperature = aiConfig.Temperature_User;
					content.tools = new List<GeminiTools>()
					{
						new GeminiTools(new TimeOutUserCall(),
						new BanUserCall(),
						new SpeedrunWRCall(),
						new SpeedrunPBCall(),
						new CurrentDateTimeCall(),
						!string.IsNullOrEmpty(AIConfig.GetInstance().WeatherAPIKey) ? new OpenWeatherCall() : null)
					};
				}

				if (content == null)
				{
					bot?.ChannelInstance?.SendChatMessage($"{request.user_name}: Failed to load user history.");
					bot?.HelixAPI_User?.UpdateRedemptionStatus(request, RedemptionStates.CANCELED);
					return;
				}
				content.StorePath = path;
				var full_input = AIMessageUtils.AppendDateTimePrefix(request.user_input);
				var result = await m_Processor.GetAIResponse(content, instructions, full_input);

				if (result == null)
				{
					bot?.ChannelInstance.SendChatMessage($"{request.user_name} - Failed to get a response. Please debug me :(");
					bot?.HelixAPI_User.UpdateRedemptionStatus(request, RedemptionStates.CANCELED);
					return;
				}
				else
				{
					content.generationConfig.TokenCount = result.usageMetadata.totalTokenCount;

					var lastResponse = result.candidates.Last().content;
					content.contents.Add(lastResponse);

					for (int i = 0; i < lastResponse.parts.Length; i++)
					{
						if (!isChannelOwner)
						{
							if (i != lastResponse.parts.Length - 1)
								continue;
						}
						var response = lastResponse.parts[i];
						bot?.HelixAPI_User.UpdateRedemptionStatus(request, RedemptionStates.FULFILLED);

						if (response.text != null)
						{
							SuiBotAIProcessor.CleanupResponse(ref response.text);

							channelInstance?.SendChatMessage($"{request.user_name}: {response.text}");

							while (content.generationConfig.TokenCount > tokenLimit)
							{
								if (content.contents.Count > 2)
								{
									//This isn't weird - we want to make sure we start from user message
									if (content.contents[0].role == Role.user)
									{
										content.contents.RemoveAt(0);
									}

									if (content.contents[0].role == Role.model)
									{
										content.contents.RemoveAt(0);
									}
								}
							}

							XML_Utils.Save(path, content);
						}

						if (response.functionCall != null)
						{
							var type = content.tools[0].Calls[response.functionCall.name];
							if (type == null)
								return;
							var converted = response.functionCall.args.ToObject(type);
							if (converted.GetType().IsSubclassOf(typeof(FunctionCallSSC)))
							{
								var callableCast = (FunctionCallSSC)converted;
								callableCast.Perform(channelInstance, (ES_ChatMessage)request, content);
							}
						}
					}
				}
			}
			catch (SafetyFilterTrippedException ex)
			{
				MainForm.Instance.TwitchBot.ChannelInstance.SendChatMessage($"Failed to get a response. Safety filter tripped!");
				MainForm.Instance.ThreadSafeAddPreviewText($"Safety was tripped {ex}", LineType.GeminiAI);
				bot?.HelixAPI_User.UpdateRedemptionStatus(request, RedemptionStates.CANCELED);
			}
			catch (Exception ex)
			{
				MainForm.Instance.TwitchBot.ChannelInstance.SendChatMessage($"Failed to get a response. Something was written in log. Help! :(");
				MainForm.Instance.ThreadSafeAddPreviewText($"There was an error trying to do AI: {ex}", LineType.GeminiAI);
			}
		}

		internal void GetSecondaryAnswer(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content, string appendContent, Role role)
		{
			ChatBot bot = MainForm.Instance.TwitchBot;

			Task.Run(async () =>
			{
				try
				{
					var result = await m_Processor.GetAIResponse(content, content.systemInstruction, appendContent, role);
					if (result == null)
					{
						bot?.ChannelInstance.SendChatMessage($"{message.chatter_user_name} - Failed to get secondary response. :(");
						return;
					}
					else
					{
						content.generationConfig.TokenCount = result.usageMetadata.totalTokenCount;
						var candidate = result?.candidates.LastOrDefault();
						if (candidate != null)
						{
							content.contents.Add(candidate.content);
							foreach (var part in candidate.content.parts)
							{
								var text = part.text;
								if (text != null)
								{
									SuiBotAIProcessor.CleanupResponse(ref text);

									channelInstance?.SendChatMessage($"{message.chatter_user_name}: {text}");
									if (!string.IsNullOrEmpty(content.StorePath))
										XML_Utils.Save(content.StorePath, content);
								}

								var func = part.functionCall;
								if (func != null)
								{
									var type = content.tools[0].Calls[func.name];
									if (type == null)
										return;
									var converted = func.args.ToObject(type);
									if (converted.GetType().IsSubclassOf(typeof(FunctionCallSSC)))
									{
										var callableCast = (FunctionCallSSC)converted;
										callableCast.Perform(channelInstance, message, content);
									}
								}
							}

						}
					}
				}
				catch (SafetyFilterTrippedException ex)
				{
					MainForm.Instance.TwitchBot.ChannelInstance.SendChatMessage($"Failed to get a response. Safety filter tripped!");
					MainForm.Instance.ThreadSafeAddPreviewText($"Safety was tripped {ex}", LineType.GeminiAI);
				}
				catch (Exception ex)
				{
					MainForm.Instance.TwitchBot.ChannelInstance.SendChatMessage($"Failed to get a response. Something was written in log. Help! :(");
					MainForm.Instance.ThreadSafeAddPreviewText($"There was an error trying to do AI: {ex}", LineType.GeminiAI);
				}
			});
		}

		private void GetResponseAdBreakStarted(ES_AdBreakBeginNotification adInfo)
		{
			var aiConfig = AIConfig.GetInstance();

			if (!aiConfig.Events.AdsBeginNotify)
				return;

			ChatBot bot = MainForm.Instance.TwitchBot;
			if (bot == null)
				return;

			Task.Factory.StartNew(async () =>
			{
				GeminiContent content = new GeminiContent
				{
					contents = new List<GeminiMessage>(),
					safetySettings = aiConfig.GetSafetySettingsStreamer(),
					tools = null,
					generationConfig = new GeminiContent.GenerationConfig()
					{
						temperature = aiConfig.Temperature_Streamer
					}
				};
				GeminiMessage instructions = aiConfig.GetCharacterInstruction();

				m_TemporaryMemoryForAdNotification = null;
				var result = await m_Processor.GetAIResponse(content, instructions, aiConfig.Events.Instruction_AdsBegin.Replace("{time}", (adInfo.duration_seconds / 60f).ToString(CultureInfo.GetCultureInfo("en-US"))));
				if (result == null)
					return;

				var candidate = result.candidates.Last();

				var text = candidate.content.parts.Last().text;
				if (text != null)
				{
					SuiBotAIProcessor.CleanupResponse(ref text);
					bot.ChannelInstance?.SendChatMessage(text);
					content.contents.Add(candidate.content);
					m_TemporaryMemoryForAdNotification = new Tuple<ES_AdBreakBeginNotification, GeminiContent>(adInfo, content);
				}
			});
		}

		private void GetResponseAdBreakFinished(ES_AdBreakBeginNotification adInfo, int nextAdsIn)
		{
			var aiConfig = AIConfig.GetInstance();

			if (!aiConfig.Events.AdsFinishNotify)
				return;

			ChatBot bot = MainForm.Instance.TwitchBot;
			if (bot == null)
				return;

			Task.Factory.StartNew(async () =>
			{
				GeminiContent content;
				if (m_TemporaryMemoryForAdNotification != null && adInfo == m_TemporaryMemoryForAdNotification.Item1)
				{
					content = m_TemporaryMemoryForAdNotification.Item2;
				}
				else
				{
					content = new GeminiContent
					{
						contents = new List<GeminiMessage>(),
						safetySettings = aiConfig.GetSafetySettingsStreamer(),
						tools = null,
						generationConfig = new GeminiContent.GenerationConfig()
						{
							temperature = aiConfig.Temperature_Streamer
						}
					};
				}

				GeminiMessage instructions = aiConfig.GetCharacterInstruction();

				m_TemporaryMemoryForAdNotification = null;
				var result = await m_Processor.GetAIResponse(content, instructions, aiConfig.Events.Instruction_AdsFinished.Replace("{next_ads}", nextAdsIn.ToString()));
				if (result == null)
					return;

				var candidate = result.candidates.Last();

				var text = candidate.content.parts.Last().text;
				if (text != null)
				{
					SuiBotAIProcessor.CleanupResponse(ref text);
					bot?.ChannelInstance?.SendChatMessage(text);
				}
			});
		}

		private void GetResponsePreRollsActivated()
		{
			var aiConfig = AIConfig.GetInstance();

			if (!aiConfig.Events.AdsPrerollsActiveNotify)
				return;
			ChatBot bot = MainForm.Instance.TwitchBot;

			Task.Factory.StartNew(async () =>
			{
				GeminiContent content = new GeminiContent
				{
					contents = new List<GeminiMessage>(),
					safetySettings = aiConfig.GetSafetySettingsStreamer(),
					tools = null,
					generationConfig = new GeminiContent.GenerationConfig()
					{
						temperature = aiConfig.Temperature_Streamer
					}
				};

				GeminiMessage instructions = aiConfig.GetCharacterInstruction();

				m_TemporaryMemoryForAdNotification = null;
				var result = await m_Processor.GetAIResponse(content, instructions, aiConfig.Events.Instruction_NotifyPrerolls);
				if (result == null)
					return;

				var candidate = result.candidates.Last();

				var text = candidate.content.parts.Last().text;
				if (text != null)
				{
					SuiBotAIProcessor.CleanupResponse(ref text);
					bot?.ChannelInstance?.SendChatMessage(text);
				}
			});
		}

		private void GetResponseRaid(ES_ChannelRaid raid)
		{
			var aiConfig = AIConfig.GetInstance();

			if (!aiConfig.Events.RaidNotify)
				return;
			ChatBot bot = MainForm.Instance.TwitchBot;

			Task.Factory.StartNew(async () =>
			{
				GeminiContent content = new GeminiContent
				{
					contents = new List<GeminiMessage>(),
					safetySettings = aiConfig.GetSafetySettingsStreamer(),
					tools = null,
					generationConfig = new GeminiContent.GenerationConfig()
					{
						temperature = aiConfig.Temperature_Streamer
					}
				};

				GeminiMessage instructions = aiConfig.GetCharacterInstruction();

				StringBuilder sb = new StringBuilder();
				sb.AppendLine(aiConfig.Events.Instruction_Raid.Replace("{user}", raid.from_broadcaster_user_name));
				sb.AppendLine();

				var channelInformation = await bot.HelixAPI_User.GetChannelInformation(raid.from_broadcaster_user_id);
				if (channelInformation == null)
					return;

				var userInfo = await bot.HelixAPI_User.GetUserInfoByUserID(raid.from_broadcaster_user_id);
				if (userInfo == null)
					return;

				sb.AppendLine($"{raid.from_broadcaster_user_name} was last seen streaming {channelInformation.game_name}.");
				sb.AppendLine($"Their stream title was {channelInformation.title}.");
				sb.AppendLine($"Their channel description is {userInfo.description}.");
				if (raid.viewers >= 10)
					sb.AppendLine($"They raided with {userInfo.view_count} viewers.");

				var result = await m_Processor.GetAIResponse(content, instructions, sb.ToString());
				if (result == null)
					return;

				var candidate = result.candidates.Last();

				var text = candidate.content.parts.Last().text;
				if (text != null)
				{
					SuiBotAIProcessor.CleanupResponse(ref text);
					bot?.ChannelInstance?.SendChatMessage(text);
				}
			});
		}
	}
}
