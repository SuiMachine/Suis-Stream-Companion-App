using SSC.DataStorage;
using SSC.DataStorage.Interfaces;
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
		}

		internal IVSSRedeem GetResult()
		{
			throw new NotImplementedException();
		}

		bool VerifyResult()
		{
			if (tabControlVSSAddType.SelectedTab == tabPageSound)
			{
				if(this.listBoxSounds.SelectedItem != null)
				{
					return true;
				}
			}
			else if (tabControlVSSAddType.SelectedTab == tabPageVideo)
			{
				// Verify video redeem
			}
			else if (tabControlVSSAddType.SelectedTab == tabPageContainer)
			{
				// Verify container redeem
			}
			return false;
		}

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

		private void bindingSourceSound_CurrentChanged(object sender, EventArgs e)
		{

		}
	}
}
