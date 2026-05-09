using SSC.DataStorage.Videos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSC.Forms.VideoRewardsDBEditor
{
	public partial class Add_Edit_Video : Form
	{
		public string RewardName;
		public string Description;
		public int Cooldown;
		public string[] Tags = new string[0];
		public string[] Files = new string[0];

		public Add_Edit_Video()
		{
			InitializeComponent();
			this.Text = "Add new entry";
		}

		public Add_Edit_Video(OBS_VideoReward rewardToEdit)
		{
			InitializeComponent();
			this.Text = "Entry editing";
			RewardName = rewardToEdit.RewardName;
			Description = rewardToEdit.Description;
			Cooldown = rewardToEdit.Cooldown;
			Tags = new string[rewardToEdit.Tags.Length];
			for (int i = 0; i < Tags.Length; i++)
				Tags[i] = rewardToEdit.Tags[i];
			for (int i = 0; i < Files.Length; i++)
				Files[i] = rewardToEdit.Files[i];
		}

		private void Verify()
		{
			if (TB_Name.Text == String.Empty)
			{
				B_OK.Enabled = false;
				return;
			}

			if (ListBox_Files.Items.Count == 0)
			{
				B_OK.Enabled = false;
				return;
			}

			for (int i = 0; i < ListBox_Files.Items.Count; i++)
			{
				if (ListBox_Files.Items[i].ToString() == String.Empty)
				{
					B_OK.Enabled = false;
					return;
				}
			}

			B_OK.Enabled = true;
		}

		public OBS_VideoReward ReturnReward { get; internal set; }

		private void B_OK_Click(object sender, EventArgs e)
		{
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
