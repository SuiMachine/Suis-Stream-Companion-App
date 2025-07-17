using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SSC.AI_Integration.CasualChatsElements
{
	public partial class EditDisplay : Form
	{
		AIConfig config;

		public EditDisplay()
		{
			InitializeComponent();
		}

		private void EditDisplay_Load(object sender, EventArgs e)
		{
			config = AIConfig.GetInstance();
			if (!string.IsNullOrEmpty(config.CasualChat_Icon_User))
			{
				TB_UserIcon.Text = config.CasualChat_Icon_User;
			}
			if (!string.IsNullOrEmpty(config.CasualChat_Icon_AI))
			{
				TB_AIIcon.Text = config.CasualChat_Icon_AI;
			}
		}

		private void B_Save_Click(object sender, EventArgs e)
		{
			config.CasualChat_Icon_User = TB_UserIcon.Text.Trim();
			config.CasualChat_Icon_AI = TB_AIIcon.Text.Trim();
			config.SaveSettings();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void B_BrowseUser_Click(object sender, EventArgs e)
		{
			var fd = new OpenFileDialog()
			{
				Filter = "Graphics files|*.webp;*.jpg;*.gif;*png"
			};
			if (fd.ShowDialog() != DialogResult.OK)
				return;
			TB_UserIcon.Text = fd.FileName;
		}

		private void B_BrowseAI_Click(object sender, EventArgs e)
		{
			var fd = new OpenFileDialog()
			{
				Filter = "Graphics files|*.webp;*.jpg;*.gif;*png"
			};
			if (fd.ShowDialog() != DialogResult.OK)
				return;
			TB_AIIcon.Text = fd.FileName;
		}

		private void TB_UserIcon_TextChanged(object sender, EventArgs e)
		{
			if (File.Exists(TB_UserIcon.Text))
			{
				if (pic_User.Image != null)
				{
					pic_User.Image.Dispose();
					pic_User.Image = null;
				}
				pic_User.Image = Image.FromFile(TB_UserIcon.Text);
			}
		}

		private void TB_AIIcon_TextChanged(object sender, EventArgs e)
		{
			if (File.Exists(TB_AIIcon.Text))
			{
				if (pic_AI.Image != null)
				{
					pic_AI.Image.Dispose();
					pic_AI.Image = null;
				}
				pic_AI.Image = Image.FromFile(TB_AIIcon.Text);
			}
		}
	}
}
