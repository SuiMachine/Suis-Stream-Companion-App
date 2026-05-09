using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
using SSC.DataStorage;
using SSC.DataStorage.Videos;
using SSC.SoundDatabaseEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SSC.Forms.VideoRewardsDBEditor
{
	public partial class VideoDBEditor : Form
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public static VideoDBEditor Instance { get; private set; }
		OBS_VideoRewardDB rewards;
		public List<OBS_VideoReward> RewardsCopy;
		public string SelectedScene;
		public string SelectedMedia;

		public VideoDBEditor(OBS_VideoRewardDB rewards)
		{
			this.rewards = rewards;
			this.RewardsCopy = new List<OBS_VideoReward>(rewards.StorableData.VideoRewards);
			for (int i = 0; i < rewards.StorableData.VideoRewards.Count; i++)
			{
				RewardsCopy[i] = rewards.StorableData.VideoRewards[i].CreateCopy();
			}

			this.SelectedScene = rewards.StorableData.OBS_Scene;
			this.SelectedMedia = rewards.StorableData.OBS_MultimediaSource;

			InitializeComponent();
			Instance = this;
		}

		private void VideoDBEditor_Load(object sender, EventArgs e)
		{
			if (MainForm.Instance.OBS != null)
			{
				MainForm.Instance.OBS.Connected += HandleOnOBSConnected;
				MainForm.Instance.OBS.Disconnected += HandleOnOBSDisconnected;
				MainForm.Instance.OBS.ExitStarted += HandleOnOBSDisconnected;
				if (MainForm.Instance.OBS.IsConnected)
				{
					UpdateOBSButton();
					RefreshScenes();
				}
			}
		}

		private void UpdateOBSButton()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(UpdateOBSButton));
				return;
			}

			var mainForm = MainForm.Instance;
			if (mainForm.OBS != null && mainForm.OBS.IsConnected)
			{
				this.B_ConnectToObs.Enabled = false;
			}
			else
			{
				this.B_ConnectToObs.Enabled = true;
			}
		}

		private void VideoDBEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Instance = null;
			if (MainForm.Instance.OBS != null)
			{
				MainForm.Instance.OBS.Connected -= HandleOnOBSConnected;
				MainForm.Instance.OBS.Disconnected -= HandleOnOBSDisconnected;
				MainForm.Instance.OBS.ExitStarted -= HandleOnOBSDisconnected;
			}
		}

		private void B_ConnectToObs_Click(object sender, EventArgs e)
		{
			var mainForm = MainForm.Instance;
			if (mainForm.OBS == null || !mainForm.OBS.IsConnected)
			{
				bool setupEvents = mainForm.OBS == null;
				mainForm.ConnectOBS(true);
				if (setupEvents)
				{
					mainForm.OBS.Connected += HandleOnOBSConnected;
					mainForm.OBS.Disconnected += HandleOnOBSDisconnected;
					mainForm.OBS.ExitStarted += HandleOnOBSDisconnected;
				}
			}
		}

		private void HandleOnOBSDisconnected(object sender, EventArgs e) => UpdateOBSButton();

		private void HandleOnOBSConnected(object sender, EventArgs e)
		{
			UpdateOBSButton();
			RefreshScenes();
		}

		private void HandleOnOBSDisconnected(object sender, ObsDisconnectionInfo e) => UpdateOBSButton();

		private void B_Refresh_Click(object sender, EventArgs e) => RefreshScenes();

		private void RefreshScenes()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(RefreshScenes));
				return;
			}

			var mainForm = MainForm.Instance;
			if (mainForm.OBS != null && mainForm.OBS.IsConnected)
			{
				SceneBasicInfo[] scenes = mainForm.OBS.GetSceneList().Scenes.ToArray();
				CB_SceneSelected.Items.Clear();
				CB_SceneSelected.Items.AddRange(scenes);
				CB_SceneSelected.DisplayMember = "Name";


				var foundScene = scenes.FirstOrDefault(x => x.Name == SelectedScene);
				if (foundScene != null)
					CB_SceneSelected.SelectedIndex = int.Parse(foundScene.Index);
				else
				{
					CB_SceneSelected.SelectedIndex = 0;
				}
			}
		}

		private void CB_SceneSelected_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox senderCast = sender as ComboBox;
			if (senderCast.SelectedIndex < 0)
				return;

			SceneBasicInfo value = senderCast.SelectedItem as SceneBasicInfo;
			SelectedScene = value.Name;

			var mainForm = MainForm.Instance;

			SceneItemDetails[] itemList = mainForm.OBS.GetSceneItemList(SelectedScene).Where(x => x.SourceType == SceneItemSourceType.OBS_SOURCE_TYPE_INPUT && x.SourceKind == "ffmpeg_source").ToArray();
			CB_MediaPlayer.Items.Clear();
			CB_MediaPlayer.Items.AddRange(itemList);
			CB_MediaPlayer.DisplayMember = "SourceName";

			SceneItemDetails foundMedia = itemList.FirstOrDefault(x => x.SourceName == SelectedMedia);
			if (foundMedia != null)
				CB_MediaPlayer.SelectedItem = foundMedia;
			else if (itemList.Length > 0)
			{
				CB_MediaPlayer.SelectedIndex = 0;
			}
		}

		private void CB_MediaPlayer_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox senderCast = sender as ComboBox;
			if (senderCast.SelectedIndex < 0)
				return;

			var selectedItem = senderCast.SelectedItem as SceneItemDetails;
			SelectedMedia = selectedItem.SourceName;
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to cancel? All unsaved changes will be lost.", "Cancel", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}
	}
}
