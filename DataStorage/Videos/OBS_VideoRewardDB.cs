using OBSWebsocketDotNet.Types;
using SSC.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static SuiBot_TwitchSocket.API.EventSub.ES_ChannelPoints;

namespace SSC.DataStorage.Videos
{
	public class OBS_VideoRewardDB
	{
		[Serializable]
		public class VideoRewardData
		{
			public string TwitchRewardID = "";
			public string OBS_Scene = "";
			public string OBS_MultimediaSource = "";
			public List<OBS_VideoReward> VideoRewards = new List<OBS_VideoReward>();
		}

		public VideoRewardData StorableData { get; private set; }
		private readonly Random m_RNG;
		public Dictionary<string, OBS_VideoReward> VideoRewardsDictionary = new Dictionary<string, OBS_VideoReward>();
		private Dictionary<string, DateTime> UserDB;
		private int m_Delay;
		private readonly string m_VideoFilesDB_File;

		public OBS_VideoRewardDB()
		{
			UserDB = new Dictionary<string, DateTime>();
			m_RNG = new Random();
			m_Delay = PrivateSettings.GetInstance().Delay;
			m_VideoFilesDB_File = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "VideoRewards.xml");
			StorableData = LoadFromXml();
		}

		#region Storage
		private VideoRewardData LoadFromXml()
		{
			VideoRewardData loadedData;
			if (!File.Exists(m_VideoFilesDB_File))
			{
				loadedData = new VideoRewardData();
				SaveDB(m_VideoFilesDB_File, loadedData);
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(VideoRewardData));
				FileStream fs = new FileStream(m_VideoFilesDB_File, FileMode.Open);
				loadedData = (VideoRewardData)xmlSerializer.Deserialize(fs);
				fs.Dispose();
			}
			return loadedData;
		}

		public void SaveDB() => SaveDB(m_VideoFilesDB_File, StorableData);

		private void SaveDB(string xmlPath, VideoRewardData entries)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(VideoRewardData));
			var folder = Directory.GetParent(m_VideoFilesDB_File).FullName;
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			FileStream fs = new FileStream(m_VideoFilesDB_File, FileMode.Create);
			xmlSerializer.Serialize(fs, entries);
			fs.Dispose();
		}
		#endregion

		public void Register()
		{
			MainForm.Instance.TwitchEvents.OnChannelPointsRedeem += PlayVideoIfExists;
		}

		public void PlayVideoIfExists(ES_ChannelPointRedeemRequest redeem)
		{
			if (redeem.state != RedemptionStates.UNFULFILLED)
				return;
			if (redeem.user_id == null)
				return;
			if (string.IsNullOrEmpty(StorableData.TwitchRewardID) || StorableData.TwitchRewardID != redeem.reward.id)
				return;

			if (ChatBot.AreRedeemsPaused)
			{
				MainForm.Instance.TwitchBot.HelixAPI_User.UpdateRedemptionStatus(redeem, RedemptionStates.CANCELED);
				return;
			}

			//Check if our db has a user and if not add him
			if (!UserDB.ContainsKey(redeem.user_id))
			{
				UserDB.Add(redeem.user_id, DateTime.MinValue);
			}

			if (UserDB[redeem.user_id] + TimeSpan.FromSeconds(m_Delay) < DateTime.Now)
			{
				var mainFormOBS = MainForm.Instance.OBS;
				if(mainFormOBS == null || !mainFormOBS.IsConnected)
				{
					MainForm.Instance.TwitchBot.HelixAPI_User.UpdateRedemptionStatus(redeem, RedemptionStates.CANCELED);
					return;
				}

/*				mainFormOBS.SetInputSettings(new InputSettings()
				{
					InputKind = "ffmpeg_source",
					InputName = StorableData.OBS_MultimediaSource,
					Settings = new Newtonsoft.Json.Linq.JObject()
					{
						{ "file", "" }
					}
				});*/
			}
			else
				MainForm.Instance.TwitchBot.HelixAPI_User.UpdateRedemptionStatus(redeem, RedemptionStates.CANCELED);
		}


		public void RebuildDictionary()
		{
			VideoRewardsDictionary.Clear();
			foreach (OBS_VideoReward entry in StorableData.VideoRewards)
			{
				if (entry.Tags.Length > 0)
				{
					foreach (string tag in entry.Tags)
					{
						//Check for collision first
						var lower_case_tag = tag.ToLower();
						if (VideoRewardsDictionary.TryGetValue(lower_case_tag, out var collidingReward))
							MainForm.Instance.ThreadSafeAddPreviewText($"Couldn't add universal reward - {entry.RewardName} and {collidingReward.RewardName} are calling with each other due to tag \"{lower_case_tag}\"", LineType.SoundCommand);
						else
							VideoRewardsDictionary.Add(lower_case_tag, entry);
					}
				}
			}
		}

	}
}
