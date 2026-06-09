using SSC.DataStorage;
using SSC.DataStorage.Interfaces;
using SSC.DataStorage.Videos;
using System;
using System.Windows.Forms;

namespace SSC.Forms.VSS.EditForms
{
	public partial class AddVSSElementForm : Form
	{
		public AddVSSElementForm()
		{
			InitializeComponent();
		}

		private void AddVSSElementForm_Load(object sender, EventArgs e)
		{
			this.listBoxSounds.BeginUpdate();
			this.listBoxSounds.DataSource = MainForm.Instance.SoundDB.SoundList;
			this.listBoxSounds.DisplayMember = nameof(SoundEntry.RewardName);
			this.listBoxSounds.EndUpdate();

			this.listBoxVideos.BeginUpdate();
			this.listBoxVideos.DataSource = MainForm.Instance.VideoDB.StorableData.VideoRewards;
			this.listBoxVideos.DisplayMember = nameof(OBS_VideoReward.RewardName);
			this.listBoxVideos.EndUpdate();
		}

		internal IVSSRedeem GetResult()
		{
			if (tabControlVSSAddType.SelectedTab == tabPageSound)
			{
				if (this.listBoxSounds.SelectedItem != null)
					return new VSS_RedeemBridgeSoundAward(this.listBoxSounds.SelectedItem as SoundEntry, Keys.None);
			}
			else if (tabControlVSSAddType.SelectedTab == tabPageVideo)
			{
				if (this.listBoxVideos.SelectedItem != null)
					return new VSS_RedeemBridgeVideoAward(this.listBoxVideos.SelectedItem as OBS_VideoReward, Keys.None);
			}
			else if (tabControlVSSAddType.SelectedTab == tabPageContainer)
			{
				if(this.TB_ContainerName.Text != null && this.TB_ContainerName.Text.Length > 0)
					return new VSS_Container(this.TB_ContainerName.Text, Keys.None);
			}
			return null;
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			if (GetResult() == null)
				return;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
