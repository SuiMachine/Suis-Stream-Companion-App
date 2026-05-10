using SSC.DataStorage.Videos;
using SSC.Extensions;
using SSC.Forms.SoundDatabaseEditor;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SSC.Forms.VideoRewardsDBEditor
{
	public partial class Add_Edit_Video : Form
	{
		public OBS_VideoReward ReturnReward { get; internal set; }

		public Add_Edit_Video()
		{
			InitializeComponent();
			this.Text = "Add new entry";
			ReturnReward = new OBS_VideoReward();
		}

		public Add_Edit_Video(OBS_VideoReward rewardToEdit)
		{
			InitializeComponent();
			this.Text = "Entry editing";
			ReturnReward = rewardToEdit.CreateCopy();
			TB_Name.Text = ReturnReward.RewardName;
			RB_Description.Text = ReturnReward.Description;
			RB_Tags.Lines = ReturnReward.Tags;
			ListBox_Files.Items.AddRange(ReturnReward.Files);

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

			if (RB_Tags.Lines.Length == 0)
			{
				B_OK.Enabled = false;
				return;
			}

			B_OK.Enabled = true;
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

		private void ListBox_Files_DragDrop(object sender, DragEventArgs e)
		{
			string[] fToAdd = (string[])e.Data.GetData(DataFormats.FileDrop);
			ListBox_Files.Items.AddRange(fToAdd);
			ReturnReward.Files = ListBox_Files.Items.Cast<string>().ToArray();
			Verify();
		}

		private void ListBox_Files_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files.All(x => SupportedVideoFileFormats.IsAcceptableVideoFormat(x)))
					e.Effect = DragDropEffects.Copy;
				else
					e.Effect = DragDropEffects.None;
			}
			else
				e.Effect = DragDropEffects.None;
		}

		private void TB_Name_TextChanged(object sender, EventArgs e)
		{
			Verify();
			ReturnReward.RewardName = TB_Name.Text;
		}

		private void RB_Description_TextChanged(object sender, EventArgs e)
		{
			Verify();
			ReturnReward.Description = RB_Description.Text;
		}


		private void RB_Tags_TextChanged(object sender, EventArgs e)
		{
			ReturnReward.Tags = RB_Tags.Lines.Select(x => x.SanitizeTags()).Where(x => x != "").ToArray();
			Verify();
		}

		private void AddToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDial = new OpenFileDialog
			{
				Filter = SupportedVideoFileFormats.Filter,
				FilterIndex = SupportedVideoFileFormats.LastIndex,
				Multiselect = true
			};

			DialogResult res = fileDial.ShowDialog();
			if (res == DialogResult.OK)
			{
				this.ListBox_Files.Items.AddRange(fileDial.FileNames);
				ReturnReward.Files = ListBox_Files.Items.Cast<string>().ToArray();
			}
			Verify();
		}

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedItems = this.ListBox_Files.SelectedItems;
			var selected = new string[selectedItems.Count];
			for (int i = 0; i < selected.Length; i++)
			{
				selected[i] = (string)selectedItems[i];
			}

			foreach (var item in selected)
			{
				this.ListBox_Files.Items.Remove(item);
			}
			ReturnReward.Files = ListBox_Files.Items.Cast<string>().ToArray();
			Verify();
		}
	}
}
