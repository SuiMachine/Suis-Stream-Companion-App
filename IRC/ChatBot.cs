﻿using SSC.Structs;
using SuiBot_TwitchSocket;
using SuiBot_TwitchSocket.API;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBot_TwitchSocket.API.EventSub.Subscription.Responses;
using SuiBot_TwitchSocket.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using static SuiBot_TwitchSocket.API.EventSub.ES_ChannelPoints;

namespace SSC.Chat
{
	public class ChatBot : IBotInstance, IDisposable
	{
		public const string SSC_CLIENT_ID = "9z58zy6ak0ejk9lme6dy6nyugydaes"; //Leftover from BTSP - va
		public static bool AreRedeemsPaused { get; internal set; } = false;
		public static bool AreVoiceRedeemsPaused { get; internal set; } = false;
		public static bool AreSoundRedeemsPaused { get; internal set; } = false;

		public bool BotRunning;
		public ChannelInstance ChannelInstance;
		internal TwitchSocket TwitchSocket { get; private set; }
		internal HelixAPI HelixAPI_User { get; private set; }
		private HelixAPI m_HelixAPI_Bot;
		internal HelixAPI HelixAPI_Bot => m_HelixAPI_Bot ?? HelixAPI_User; //Use user if bot is null

		public bool ShouldRun { get; set; }
		public bool IsDisposed { get; private set; }

		private MainForm m_Parent;
		private string m_ChannelToJoin;
		private char m_PrefixChar;
		public System.Timers.Timer StatusUpdateTimer;
		private System.Timers.Timer m_PreRolsActiveNotificationTimer;

		public SoundDB SndDB { get; private set; }

		public ChatBot(SoundDB soundDb, char PrefixChar)
		{
			var privateSettings = PrivateSettings.GetInstance();

			ChannelInstance = new ChannelInstance(this);
			HelixAPI_User = new HelixAPI(SSC_CLIENT_ID, this, privateSettings.UserAuth);

			if (privateSettings.BotAuth != "")
				m_HelixAPI_Bot = new HelixAPI(SSC_CLIENT_ID, this, privateSettings.BotAuth);

			var authVerify = HelixAPI_User.GetValidation();
			if (authVerify == null || string.IsNullOrEmpty(authVerify.login))
				throw new Exception("Failed to validate user token - a new one might need to be generated?");
			m_ChannelToJoin = authVerify.login;
			ChannelInstance.Channel = m_ChannelToJoin;
			ChannelInstance.ChannelID = authVerify.user_id;

			if (m_HelixAPI_Bot != null)
			{
				var validationResult = m_HelixAPI_Bot.ValidateToken();
				if (validationResult != HelixAPI.ValidationResult.Successful)
					throw new Exception($"Failed to validate bot token. Validation status was {validationResult}");
			}

			m_Parent = MainForm.Instance;
			this.StatusUpdateTimer = new System.Timers.Timer(5 * 1000 * 60) { AutoReset = true };
			this.StatusUpdateTimer.Elapsed += StatusUpdateTimer_Elapsed;
			this.m_PrefixChar = PrefixChar;
			SndDB = soundDb;
			SndDB.Register();
			m_Parent.MixItUpWebhook.Register();
			this?.HelixAPI_Bot.GetStatus(ChannelInstance);
		}

		private void StatusUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			ChannelInstance.UpdateTwitchStatus();
		}

		internal void Connect()
		{
			VoiceModHandling.GetInstance().ConnectToVoiceMod();

			ShouldRun = true;
			TwitchSocket = new TwitchSocket(this);
		}

		public void StopBot()
		{
			SndDB.Close();
			PrivateSettings.GetInstance().SaveSettings();
			ChannelInstance.SaveIgnoredList();

			System.Threading.Thread.Sleep(200);
		}

		internal void UpdateVolume() => SndDB.ChangeVolume(PrivateSettings.GetInstance().Volume);

		#region EventHandlers
		public bool GetChannelInstanceUsingLogin(string login, out IChannelInstance channel)
		{
			if (login == ChannelInstance.Channel)
			{
				channel = ChannelInstance;
				return true;
			}
			else
			{
				channel = null;
				return false;
			}
		}

		public void TwitchSocket_Connected()
		{
			Logger.AddLine("Connected!");
			/*#if DEBUG
						MainForm.Instance.AI.PointsRedeem(new ES_ChannelPointRedeemRequest()
						{
							reward = new ES_ChannelPointRedeemRequest.Reward()
							{
								id = AIConfig.GetInstance().TwitchAwardID,

							},
							user_input = "What's streamer's personal best time for Deus Ex?",
							id = Guid.NewGuid().ToString(),
							broadcaster_user_id = HelixAPI_User.BotUserId,
							broadcaster_user_login = HelixAPI_User.BotLoginName,
							broadcaster_user_name = HelixAPI_User.BotLoginName,
							user_id = HelixAPI_User.BotUserId,
							user_login = HelixAPI_User.BotLoginName,
							user_name = HelixAPI_User.BotLoginName,
							state = RedemptionStates.UNFULFILLED,
							redeemed_at = DateTime.UtcNow,
						});
			#endif*/
			Task.Factory.StartNew(async () =>
			{
				Response_SubscribeTo.Subscription_Response_Data result = await HelixAPI_User.SubscribeToChatMessageUsingID(HelixAPI_User.User_Id, TwitchSocket.SessionID);
				await Task.Delay(2000);

				Response_SubscribeTo currentSubscriptionChecks = await HelixAPI_User.GetCurrentEventSubscriptions();
				foreach (var subscription in currentSubscriptionChecks.data)
				{
					if (subscription.status != "enabled" || subscription.transport.session_id != TwitchSocket.SessionID)
					{
						m_Parent?.ThreadSafeAddPreviewText($"Unsubscribing from {subscription.type} ({subscription.status})", LineType.TwitchSocketCommand);
						Logger.AddLine($"Unsubscribing from {subscription.type} ({subscription.status})");
						await HelixAPI_User.CloseSubscription(subscription);
						await Task.Delay(100);
					}
				}

				Logger.AddLine($"Subscribing to additional events for {result.condition.broadcaster_user_id}");
				var raid = await HelixAPI_User.SubscribeToRaidNotification(result.condition.user_id, TwitchSocket.SessionID);
				await Task.Delay(2000);
				var ads = await HelixAPI_User.SubscribeToChannelAdBreak(result.condition.user_id, TwitchSocket.SessionID);
				await Task.Delay(2000);
				var onLineSub = await HelixAPI_User.SubscribeToOnlineStatus(result.condition.broadcaster_user_id, TwitchSocket.SessionID);
				await Task.Delay(2000);
				var offlineSub = await HelixAPI_User.SubscribeToOfflineStatus(result.condition.broadcaster_user_id, TwitchSocket.SessionID);
				await Task.Delay(2000);
				var redeems = await HelixAPI_User.SubscribeToChannelRedeem(result.condition.broadcaster_user_id, TwitchSocket.SessionID);
				await Task.Delay(2000);
				var goalEnd = await HelixAPI_User.SubscribeToGoalEnd(result.condition.broadcaster_user_id, TwitchSocket.SessionID);
				m_Parent?.ThreadSafeAddPreviewText("Registered to events", LineType.TwitchSocketCommand);
				Logger.AddLine($"Done!");
			});

			StatusUpdateTimer.Start();
		}

		public void TwitchSocket_Disconnected()
		{
			m_Parent.ThreadSafeAddPreviewText("Socket disconnected", LineType.TwitchSocketCommand);

			StatusUpdateTimer.Stop();
		}

		public void TwitchSocket_ClosedViaSocket()
		{
			m_Parent.ThreadSafeAddPreviewText("Connection closed via socket", LineType.TwitchSocketCommand);

		}

		public void TwitchSocket_ChatMessage(ES_ChatMessage chatMessage)
		{
			if (!chatMessage.message.text.StartsWith(m_PrefixChar.ToString()) || ChannelInstance.IgnoreList.Contains(chatMessage.chatter_user_login))
			{
				//literally nothing else happens in your code if this is false
				m_Parent.ThreadSafeAddPreviewText($"{chatMessage.chatter_user_name}: {chatMessage.message.text}", LineType.Generic);
				return;
			}
			else
			{
				string text = chatMessage.message.text.Remove(0, 1).ToLower();
				var role = TwitchRightsEnum.Public;

				//Mod Commands
				if (role >= TwitchRightsEnum.Mod || chatMessage.UserRole <= ES_ChatMessage.Role.Mod)
				{
					if (text == "stopallsounds")
					{
						m_Parent.ThreadSafeAddPreviewText($"{chatMessage.chatter_user_name}: {chatMessage.message.text}", LineType.ModCommand);
						SndDB.StopAllSounds();
						return;
					}

					if (text.StartsWith("cooldown "))
					{
						var split = text.Split(' ');
						text = split[split.Length - 1];
						if (int.TryParse(text, out int delayValue))
						{
							if (delayValue < 0)
								delayValue = 0;
							this.SndDB.SetDelay(delayValue);
						}

						m_Parent.ThreadSafeAddPreviewText($"{chatMessage.chatter_user_name}: {chatMessage.message.text}", LineType.ModCommand);
						return;
					}
				}
			}
		}

		public void TwitchSocket_StreamWentOnline(ES_StreamOnline onlineData)
		{
			m_Parent.ThreadSafeAddPreviewText("Streamer went online", LineType.TwitchSocketCommand);
		}

		public void TwitchSocket_StreamWentOffline(ES_StreamOffline offlineData)
		{
			m_Parent.ThreadSafeAddPreviewText("Streamer went offline", LineType.TwitchSocketCommand);
		}

		public void TwitchSocket_AutoModMessageHold(ES_AutomodMessageHold messageHold) { }

		public void TwitchSocket_SuspiciousMessageReceived(ES_Suspicious_UserMessage suspiciousMessage) { }

		public void TwitchSocket_ChannelPointsRedeem(ES_ChannelPointRedeemRequest redeemInfo)
		{
			if (redeemInfo.broadcaster_user_id == ChannelInstance.ChannelID)
				m_Parent.TwitchEvents.OnChannelPointsRedeem?.Invoke(redeemInfo);
		}

		public void Dispose()
		{
			m_Parent?.TwitchEvents.Clear();

			StatusUpdateTimer.Elapsed -= StatusUpdateTimer_Elapsed;
			StatusUpdateTimer.Dispose();
		}

		public void TwitchSocket_OnChannelGoalEnd(ES_ChannelGoal channelGoalEnded)
		{
			if (channelGoalEnded.is_achieved.HasValue && channelGoalEnded.is_achieved.Value)
			{
				MainForm.Instance?.TwitchEvents?.OnChannelGoalAchieved?.Invoke(channelGoalEnded);
			}
		}

		public void TwitchSocket_AdBreakBegin(ES_AdBreakBeginNotification infoAboutAd)
		{
			if (m_PreRolsActiveNotificationTimer != null)
			{
				m_PreRolsActiveNotificationTimer.Dispose();
				m_PreRolsActiveNotificationTimer = null;
			}

			MainForm.Instance?.TwitchEvents?.OnAdBreakStarted?.Invoke(infoAboutAd);
		}

		public void TwitchSocket_AdBreakFinished(ES_AdBreakBeginNotification infoAboutAd)
		{
			if (m_PreRolsActiveNotificationTimer != null)
			{
				m_PreRolsActiveNotificationTimer.Dispose();
				m_PreRolsActiveNotificationTimer = null;
			}

			//Calculate when prerolls get activated and wait additional 30s just in case!
			var prerollsActivation = (infoAboutAd.duration_seconds * 20) + 30;

			m_PreRolsActiveNotificationTimer = new System.Timers.Timer(prerollsActivation * 1000)
			{
				AutoReset = false
			};

			m_PreRolsActiveNotificationTimer.Elapsed += (sender, args) =>
			{
				MainForm.Instance?.TwitchEvents?.OnAdPrerollsActive?.Invoke();
			};
			m_PreRolsActiveNotificationTimer.Start();


			MainForm.Instance?.TwitchEvents?.OnAdBreakFinished?.Invoke(infoAboutAd, prerollsActivation / 60);

		}

		public void TwitchSocket_ChannelRaid(ES_ChannelRaid raidInfo)
		{
			if (raidInfo.to_broadcaster_user_id != ChannelInstance.ChannelID)
				return;

			MainForm.Instance?.TwitchEvents?.OnChannelRaid?.Invoke(raidInfo);
		}
		#endregion
	}
}
