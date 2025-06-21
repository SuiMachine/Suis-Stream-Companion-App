using System;
using System.Windows.Forms;

namespace SSC.AI_Integration
{
	public partial class AI_Weather_Setting : Form
	{
		public AI_Weather_Setting()
		{
			InitializeComponent();
		}

		private void AI_Weather_Setting_Load(object sender, EventArgs e)
		{
			TB_Key.Text = AIConfig.GetInstance().WeatherAPIKey;
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			AIConfig config = AIConfig.GetInstance();
			config.WeatherAPIKey = TB_Key.Text.Trim();
			config.SaveSettings();

			this.DialogResult = DialogResult.OK;
		}
	}
}
