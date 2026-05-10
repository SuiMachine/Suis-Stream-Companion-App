using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types;
using SSC.Chat;
using SSC.DataStorage;
using SSC.DataStorage.Videos;
using SSC.Extensions;
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

			foreach (var videoReward in RewardsCopy)
			{
				videosTreeView.Nodes.Add(videoReward.ToTreeNode());
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

		private void B_CreateReward_Click(object sender, EventArgs e)
		{
			Action content = new Action(async () =>
			{
				var settings = PrivateSettings.GetInstance();

				var api = new SuiBot_TwitchSocket.API.HelixAPI(ChatBot.SSC_CLIENT_ID, null, settings.UserAuth);
				var authentication = api.ValidateToken();
				if (authentication != SuiBot_TwitchSocket.API.HelixAPI.ValidationResult.Successful)
				{
					MessageBox.Show("API authentication failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				if (!await api.CreateRewardsCache())
				{
					MessageBox.Show("Failed to get rewards.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var foundReward = api.RewardsCache.FirstOrDefault(x => x.id == rewards.StorableData.TwitchRewardID);
				if (foundReward != null)
				{
					MessageBox.Show("A reward already exists and wasn't updated", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					var result = await api.CreateOrUpdateReward(null, "Video reward", "Play a video (provide a name or a phrase)", 160, 0, true, true);
					if (result != null)
					{
						if (string.IsNullOrEmpty(rewards.StorableData.TwitchRewardID))
							MessageBox.Show("A reward was missing and was created - make sure this is OK", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						else
							MessageBox.Show("Created a reward!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

						MainForm.Instance.VideoDB.StorableData.TwitchRewardID = result.id;
						MainForm.Instance.VideoDB.SaveDB();
						rewards.StorableData.TwitchRewardID = result.id;
					}
				}

				DialogBoxes.ProgressDisplay.Instance?.InvokeClose();
			});

			DialogBoxes.ProgressDisplay progressForm = DialogBoxes.ProgressDisplay.CreateIfNeeded().SetupForm(this, "Creating/Verifying universal reward", content);
		}

		private void B_Add_Click(object sender, EventArgs e)
		{
			var form = new Add_Edit_Video();
			if (form.ShowDialog() == DialogResult.OK)
			{
				RewardsCopy.Add(form.ReturnReward);
				videosTreeView.Nodes.Add(form.ReturnReward.ToTreeNode());
			}
		}


		private void B_Remove_Click(object sender, EventArgs e) => RemoveEntry();

		private void RemoveEntry()
		{
			if (videosTreeView.SelectedNode != null)
			{
				var id = videosTreeView.SelectedNode.Index;
				RewardsCopy.RemoveAt(id);
				videosTreeView.Nodes.RemoveAt(id);
			}
		}

		private void B_Sort_Click(object sender, EventArgs e)
		{
			RewardsCopy = RewardsCopy.OrderBy(x => x.RewardName).ToList();
			videosTreeView.Nodes.Clear();
			foreach (var videoReward in RewardsCopy)
			{
				videosTreeView.Nodes.Add(videoReward.ToTreeNode());
			}
		}
	}

	static class EditorExtensions
	{
		enum TreeIcons
		{
			None = 0,
			RewardVideo = 0,
			Files = 0,
			Description = 3,
		}

		public static TreeNode ToTreeNode(this OBS_VideoReward videoReward)
		{
			if (videoReward.GetIsProperEntry())
			{
				var mainIcon = (int)TreeIcons.RewardVideo;

				var newNode = new TreeNode(videoReward.RewardName)
				{
					Name = DB_Editor.NodeNameEntry,
					ImageIndex = mainIcon,
					SelectedImageIndex = mainIcon,
					StateImageIndex = mainIcon,
				};

				var Description = newNode.Nodes.Add(DB_Editor.NodeDescription);
				Description.ImageIndex = (int)TreeIcons.Description;
				Description.SelectedImageIndex = (int)TreeIcons.Description;
				Description.StateImageIndex = (int)TreeIcons.Description;
				Description.Name = DB_Editor.NodeDescription;
				Description.Text = videoReward.Description;

				var FilesNode = newNode.Nodes.Add(DB_Editor.NodeNameFiles);
				FilesNode.ImageIndex = (int)TreeIcons.Files;
				FilesNode.SelectedImageIndex = (int)TreeIcons.Files;
				FilesNode.StateImageIndex = (int)TreeIcons.Files;
				FilesNode.Name = DB_Editor.NodeNameFiles;

				foreach (var file in videoReward.Files)
				{
					if (file.RemoveWhitespaces() != String.Empty)
					{
						var fNode = FilesNode.Nodes.Add(file);
						fNode.ImageIndex = mainIcon;
						fNode.SelectedImageIndex = mainIcon;
						fNode.StateImageIndex = mainIcon;
					}
				}

				return newNode;
			}
			else
				throw new Exception(videoReward.RewardName + " is an incorrect entry!");
		}
	}

}
