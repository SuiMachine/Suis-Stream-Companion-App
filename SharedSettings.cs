using SSC.Extensions;
using SSC.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SSC
{
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
		[XmlElement] public bool Debug_mode { get; set; }
		[XmlElement] public bool Autostart { get; set; }
		[XmlElement] public float Volume { get; set; }
		[XmlElement] public int Delay { get; set; }
		[XmlElement] public Guid OutputDevice { get; set; }
		[XmlElement] public EncryptedString UserAuth { get; set; }
		[XmlElement] public EncryptedString BotAuth { get; set; }
		[XmlElement] public bool RunWebSocketsServer { get; set; }
		[XmlElement] public int WebSocketsServerPort { get; set; }
		[XmlElement] public string UniversalRewardID { get; set; }
		[XmlElement] public string LastNotesFile { get; set; }
		#endregion

		public PrivateSettings()
		{
			//NOTE: Make sure everything is initialized first!
			Debug_mode = false;
			Autostart = false;
			Volume = 0.5f;
			Delay = 15;

			UserAuth = "";
			BotAuth = "";
			RunWebSocketsServer = false;
			WebSocketsServerPort = 8005;
			UniversalRewardID = "";
			LastNotesFile = "";
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
}
