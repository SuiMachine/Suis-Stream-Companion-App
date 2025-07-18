﻿using System.ComponentModel;
using System.Windows.Forms;

namespace SSC.SettingsForms.EditForm
{
	public partial class VoiceModEditForm : Form
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string RewardName { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string VoiceName { get; set; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string RewardID { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int RewardPrice { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int RewardCooldown { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public int RewardDuration { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public bool RewardEnabled { get; set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public string RewardText { get; set; }

		public VoiceModEditForm(VoiceModConfig.VoiceModReward reward)
		{
			InitializeComponent();
			RewardName = reward.RewardTitle;
			VoiceName = reward.VoiceModFriendlyName;
			RewardID = reward.RewardID;
			RewardPrice = reward.RewardCost;
			RewardCooldown = reward.RewardCooldown;
			RewardDuration = reward.RewardDuration;
			RewardEnabled = reward.Enabled;
			RewardText = reward.RewardDescription;


			TB_Name.DataBindings.Add("Text", this, nameof(RewardName), false, DataSourceUpdateMode.OnPropertyChanged);
			TB_VoiceName.DataBindings.Add("Text", this, nameof(VoiceName), false, DataSourceUpdateMode.OnPropertyChanged);
			TB_RewardTwitchID.DataBindings.Add("Text", this, nameof(RewardID), false, DataSourceUpdateMode.OnPropertyChanged);
			NumBox_Price.DataBindings.Add("Value", this, nameof(RewardPrice), false, DataSourceUpdateMode.OnPropertyChanged);
			NumBox_Cooldown.DataBindings.Add("Value", this, nameof(RewardCooldown), false, DataSourceUpdateMode.OnPropertyChanged);
			NumBox_Duration.DataBindings.Add("Value", this, nameof(RewardDuration), false, DataSourceUpdateMode.OnPropertyChanged);
			CB_Enabled.DataBindings.Add("Checked", this, nameof(RewardEnabled), false, DataSourceUpdateMode.OnPropertyChanged);
			RB_Description.DataBindings.Add("Text", this, nameof(RewardText), false, DataSourceUpdateMode.OnValidation);
		}

		private void B_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void B_OK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void B_GenerateDescription_Click(object sender, System.EventArgs e)
		{
			var result = MessageBox.Show("Performing this will override reward name and description. Are you sure you want to continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				RewardName = $"Set voice to \"{VoiceName}\"";
				RewardText = $"Set the voice to \"{VoiceName}\" for {RewardDuration} seconds (powered by VoiceMod)";
				TB_Name.Text = RewardName;
				RB_Description.Text = RewardText;
			}
		}
	}
}
