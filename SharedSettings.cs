﻿using SSC.Extensions;
using SSC.Interfaces;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static SuiBotAI.Components.Other.Gemini.GeminiSafetySettingsCategory;

namespace SSC
{
	[Serializable]
	public class ColorStruct
	{
		//Form background
		[XmlElement]
		public ColorWrapper FormBackground { get; set; }
		[XmlElement]
		public ColorWrapper FormTextColor { get; set; }

		//MenuStripBar
		[XmlElement]
		public ColorWrapper MenuStripBarBackground { get; set; }
		[XmlElement]
		public ColorWrapper MenuStripBarText { get; set; }

		//MenuStripColors
		[XmlElement]
		public ColorWrapper MenuStripBackground { get; set; }
		[XmlElement]
		public ColorWrapper MenuStripText { get; set; }
		[XmlElement]
		public ColorWrapper MenuStripBackgroundSelected { get; set; }

		//LineColors
		[XmlElement]
		public ColorWrapper LineColorBackground { get; set; }
		[XmlElement]
		public ColorWrapper LineColorGeneric { get; set; }
		[XmlElement]
		public ColorWrapper LineColorIrcCommand { get; set; }
		[XmlElement]
		public ColorWrapper LineColorModeration { get; set; }
		[XmlElement]
		public ColorWrapper LineColorSoundPlayback { get; set; }
		[XmlElement]
		public ColorWrapper LineColorWebSocket { get; set; }

		public ColorStruct()
		{
			FormBackground = Color.WhiteSmoke;
			FormTextColor = Color.Black;

			MenuStripBarBackground = Color.WhiteSmoke;
			MenuStripBarText = Color.Black;

			MenuStripBackground = Color.WhiteSmoke;
			MenuStripText = Color.Black;
			MenuStripBackgroundSelected = Color.SkyBlue;

			LineColorBackground = Color.GhostWhite;
			LineColorGeneric = Color.Black;
			LineColorIrcCommand = Color.DarkGreen;
			LineColorModeration = Color.DarkBlue;
			LineColorSoundPlayback = Color.DarkOrange;
			LineColorWebSocket = Color.DarkMagenta;
		}
	}

	[Serializable]
	public class PrivateSettings
	{
		private static string GetConfigPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "Config.xml");
		private static PrivateSettings m_Instance;
		public static PrivateSettings GetInstance()
		{
			if (m_Instance == null)
				m_Instance = LoadSettings();

			return m_Instance;
		}

		#region Properties
		[XmlElement] public ColorStruct Colors { get; set; }

		[XmlElement] public bool Debug_mode { get; set; }
		[XmlElement] public bool Autostart { get; set; }
		[XmlElement] public float Volume { get; set; }
		[XmlElement] public int Delay { get; set; }
		[XmlElement] public Guid OutputDevice { get; set; }
		[XmlElement] public EncryptedString UserAuth { get; set; }
		[XmlElement] public EncryptedString BotAuth { get; set; }
		[XmlElement] public bool RunWebSocketsServer { get; set; }
		[XmlElement] public int WebSocketsServerPort { get; set; }
		[XmlElement] public string MixItUpWebookURL { get; set; }
		[XmlElement] public string UniversalRewardID { get; set; }
		#endregion

		public PrivateSettings()
		{
			//NOTE: Make sure everything is initialized first!
			Debug_mode = false;
			Autostart = false;
			Volume = 0.5f;
			Delay = 15;
			this.Colors = new ColorStruct();

			UserAuth = "";
			BotAuth = "";
			RunWebSocketsServer = false;
			WebSocketsServerPort = 8005;
			UniversalRewardID = "";
		}

		#region Load/Save
		private static PrivateSettings LoadSettings()
		{
			var path = GetConfigPath();
			if (File.Exists(path))
			{
				PrivateSettings obj;
				XmlSerializer serializer = new XmlSerializer(typeof(PrivateSettings));
				FileStream fs = new FileStream(path, FileMode.Open);
				obj = (PrivateSettings)serializer.Deserialize(fs);
				fs.Close();
				return obj;
			}
			else
				return new PrivateSettings();
		}

		public void SaveSettings() => XML_Utils.Save(GetConfigPath(), this);
		#endregion
	}

	[Serializable]
	public class VoiceModConfig
	{
		private static string GetConfigPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "VoiceModConfig.xml");
		private static VoiceModConfig m_Instance;
		public static VoiceModConfig GetInstance()
		{
			if (m_Instance == null)
				m_Instance = LoadSettings();

			return m_Instance;
		}

		private static VoiceModConfig LoadSettings()
		{
			if (File.Exists(GetConfigPath()))
			{
				VoiceModConfig obj;
				XmlSerializer serializer = new XmlSerializer(typeof(VoiceModConfig));
				FileStream fs = new FileStream(GetConfigPath(), FileMode.Open);
				obj = (VoiceModConfig)serializer.Deserialize(fs);
				fs.Close();
				return obj;
			}
			else
				return new VoiceModConfig();
		}

		public void Save()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(VoiceModConfig));
			StreamWriter fw = new StreamWriter(GetConfigPath());
			serializer.Serialize(fw, this);
			fw.Close();
		}

		public string APIKey { get; set; }
		public string AdressPort { get; set; }

		public List<VoiceModReward> Rewards { get; set; } = new List<VoiceModReward>();
		private Dictionary<string, VoiceModReward> IDToReward;

		public VoiceModReward GetReward(string rewardID)
		{
			if (IDToReward == null)
			{
				IDToReward = new Dictionary<string, VoiceModReward>();
				foreach (var reward in Rewards)
				{
					if (string.IsNullOrEmpty(reward.RewardID))
						continue;
					if (IDToReward.ContainsKey(reward.RewardID))
						continue;

					IDToReward.Add(reward.RewardID, reward);
				}
			}

			if (IDToReward.TryGetValue(rewardID, out var foundReward))
				return foundReward;
			else
				return null;
		}

		public VoiceModConfig()
		{
			APIKey = "";
			AdressPort = "ws://localhost:59129/v1";
		}

		[Serializable]
		public class VoiceModReward : IVoiceModeRewardBindingInterface
		{
			[XmlAttribute]
			public string VoiceModFriendlyName { get; set; }
			[XmlAttribute]
			public string RewardTitle { get; set; }
			[XmlAttribute]
			public string RewardID { get; set; }
			[XmlAttribute]
			public int RewardCost { get; set; }
			[XmlAttribute]
			public int RewardCooldown { get; set; }
			[XmlAttribute]
			public int RewardDuration { get; set; }
			[XmlAttribute]
			public bool Enabled { get; set; }
			[XmlText]
			public string RewardDescription { get; set; }
			[XmlIgnore]
			public bool IsSetup = false;

			public VoiceModReward()
			{
				VoiceModFriendlyName = "";
				RewardTitle = "";
				RewardID = "";
				RewardCost = 240;
				RewardDuration = 30;
				RewardCooldown = 1;
				Enabled = true;
				RewardDescription = "";
			}

			public object Clone()
			{
				return new VoiceModReward()
				{
					VoiceModFriendlyName = this.VoiceModFriendlyName,
					RewardTitle = this.RewardTitle,
					RewardID = this.RewardID,
					RewardCost = this.RewardCost,
					RewardCooldown = this.RewardCooldown,
					RewardDuration = this.RewardDuration,
					Enabled = this.Enabled,
					RewardDescription = this.RewardDescription
				};
			}
		}
	}

	[Serializable]
	public class AIConfig
	{
		private static AIConfig LoadSettings() => XML_Utils.Load(GetConfigPath(), new AIConfig());

		[Serializable]
		public class EventSettings
		{
			public string Instruction_AdsBegin = "Notify users in the chat that the ads (commercials) have just started and they will least for {time} minutes. The response should be between 50-450 characters long. Stay in character.";
			public string Instruction_AdsFinished = "Notify users in the chat that the ads (commercials) just finished and that next ones should be in {next_ads} minutes. Stay in character.  The response should be between 50-450 characters long.";
			public string Instruction_NotifyPrerolls = "Notify users in the chat that pre-roll ads (commercials) are now sadly activated. Stay in character. The response should be between 50-450 characters long.";
			public string Instruction_Raid = "Thank {user} for the raid. Provide a short description of who they are based and what they were streaming. The response should be between 250-450 characters long. Stay in character. Make sure the response doesn't have racist tones.";

			public bool AdsBeginNotify { get; set; } = false;
			public bool AdsFinishNotify { get; set; } = false;
			public bool AdsPrerollsActiveNotify { get; set; } = false;
			public bool RaidNotify { get; set; } = false;
		}

		[Serializable]
		public class FilterSet
		{
			public AISafetySettingsValues Harassment { get; set; } = AISafetySettingsValues.BLOCK_ONLY_HIGH;
			public AISafetySettingsValues Hate { get; set; } = AISafetySettingsValues.BLOCK_ONLY_HIGH;
			public AISafetySettingsValues Sexually_Explicit { get; set; } = AISafetySettingsValues.BLOCK_ONLY_HIGH;
			public AISafetySettingsValues Dangerous_Content { get; set; } = AISafetySettingsValues.BLOCK_ONLY_HIGH;
			public AISafetySettingsValues Civic_Integrity { get; set; } = AISafetySettingsValues.BLOCK_LOW_AND_ABOVE;
		}

		private static string GetConfigPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "AI_Config.xml");
		public static string GetAIHistoryPath(string username) => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "AI_History", username + ".xml");

		private static AIConfig m_Instance;
		public static AIConfig GetInstance()
		{
			if (m_Instance == null)
				m_Instance = LoadSettings();

			return m_Instance;
		}

		public string TwitchUsername { get; set; } = "";
		public EncryptedString ApiKey { get; set; } = "";
		public EncryptedString WeatherAPIKey { get; set; } = "";

		public string Instruction_Character { get; set; } = "Describe your character here";
		public string Instruction_Streamer { get; set; } = "The responses are always 200-550 characters long.";
		public int TokenLimit_Streamer { get; set; } = 1_048_576 - 8096 - 512;
		public float Temperature_Streamer { get; set; } = 1f;
		public FilterSet FilterSet_Streamer = new FilterSet()
		{
			Harassment = AISafetySettingsValues.BLOCK_NONE,
			Hate = AISafetySettingsValues.BLOCK_NONE,
			Sexually_Explicit = AISafetySettingsValues.BLOCK_NONE,
			Dangerous_Content = AISafetySettingsValues.BLOCK_NONE,
			Civic_Integrity = AISafetySettingsValues.BLOCK_LOW_AND_ABOVE,
		};
		public string Instruction_User { get; set; } = "The user is {0}\nThe responses are always 200-450 characters long.";
		public int TokenLimit_User { get; set; } = 8096;
		public float Temperature_User { get; set; } = 0.85f;
		public FilterSet FilterSet_User = new FilterSet()
		{
			Harassment = AISafetySettingsValues.BLOCK_MEDIUM_AND_ABOVE,
			Hate = AISafetySettingsValues.BLOCK_MEDIUM_AND_ABOVE,
			Sexually_Explicit = AISafetySettingsValues.BLOCK_MEDIUM_AND_ABOVE,
			Dangerous_Content = AISafetySettingsValues.BLOCK_MEDIUM_AND_ABOVE,
			Civic_Integrity = AISafetySettingsValues.BLOCK_LOW_AND_ABOVE,
		};

		public string Model { get; set; } = "models/gemini-2.5-flash-preview-05-20";
		public string TwitchAwardID { get; set; } = "";
		public EventSettings Events = new EventSettings();

		public void SaveSettings() => XML_Utils.Save(GetConfigPath(), this);

		public GeminiSafetySettingsCategory[] GetSafetySettingsStreamer()
		{
			return new GeminiSafetySettingsCategory[]
			{
				new GeminiSafetySettingsCategory("HARM_CATEGORY_HARASSMENT", FilterSet_Streamer.Harassment),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_HATE_SPEECH", FilterSet_Streamer.Hate),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_SEXUALLY_EXPLICIT", FilterSet_Streamer.Sexually_Explicit),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_DANGEROUS_CONTENT", FilterSet_Streamer.Dangerous_Content),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_CIVIC_INTEGRITY", FilterSet_Streamer.Civic_Integrity),
			};
		}

		public GeminiSafetySettingsCategory[] GetSafetySettingsGeneral()
		{
			return new GeminiSafetySettingsCategory[]
			{
				new GeminiSafetySettingsCategory("HARM_CATEGORY_HARASSMENT", FilterSet_User.Harassment),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_HATE_SPEECH", FilterSet_User.Hate),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_SEXUALLY_EXPLICIT", FilterSet_User.Sexually_Explicit),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_DANGEROUS_CONTENT", FilterSet_User.Dangerous_Content),
				new GeminiSafetySettingsCategory("HARM_CATEGORY_CIVIC_INTEGRITY", FilterSet_User.Civic_Integrity),
			};
		}

		public GeminiMessage GetInstruction(string username, bool isStreamer, bool attachIsLive)
		{
			var sb = new StringBuilder();

			sb.AppendLine(Instruction_Character);
			sb.AppendLine();
			sb.AppendLine(isStreamer ? Instruction_Streamer : Instruction_User);
			if (!isStreamer)
				sb.AppendLine("The user is " + username + ".");


			sb.AppendStreamInstructionPostfix(attachIsLive);

			return new GeminiMessage()
			{
				role = Role.user,
				parts = new GeminiResponseMessagePart[]
				{
					new GeminiResponseMessagePart()
					{
						text = sb.ToString()
					}
				}
			};
		}

		public GeminiMessage GetCharacterInstruction()
		{
			return new GeminiMessage()
			{
				role = Role.user,
				parts = new GeminiResponseMessagePart[]
				{
					new GeminiResponseMessagePart()
					{
						text = Instruction_Character
					}
				}
			};
		}
	}
}
