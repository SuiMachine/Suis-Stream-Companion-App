using System;
using System.Windows.Forms;

namespace SSC
{
	public partial class UniversalMessageBox : Form
	{
		public int Option { get; private set; }

		public UniversalMessageBox(string header, string text1, string text2, string text3)
		{
			InitializeComponent();
			this.Text = header;
			this.button1.Text = text1;
			this.button2.Text = text2;
			this.button3.Text = text3;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Option = 1;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Option = 2;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.Option = 3;
			this.DialogResult = DialogResult.OK;
			this.Close();
			this.Close();
		}
	}
}
