using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SSC.AI_Integration
{
	public partial class AI_Casual_Chats : Form
	{
		public static AI_Casual_Chats Instance { get; private set; }
		private GeminiAI ai;
		private List<GeminiMessage> messagesToDisplay;

		public AI_Casual_Chats(GeminiAI ai)
		{
			InitializeComponent();
			this.ai = ai;
		}

		private void AI_Casual_Chats_Load(object sender, EventArgs e)
		{
			ai.OnStreamerContentUpdated += RefreshHistory;
			RefreshHistory();
		}

		private void RefreshHistory()
		{
			int counter = 0;
			chatHistory.Controls.Clear();
			if(!ai.IsConfigured())
			{
				MessageBox.Show("AI isn't properly configured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			List<GeminiMessage> messagesToDisplay = new List<GeminiMessage>();
			for (int i = ai.StreamerContent.contents.Count - 1; i >= 0; i--)
			{
				var message = ai.StreamerContent.contents[i];
				messagesToDisplay.Add(message);
				counter++;
				if (counter >= 25)
					break;
			}

			messagesToDisplay.Reverse();

			foreach(var messageToDisplay in messagesToDisplay)
			{
				chatHistory.Controls.Add(new CasualChatsElements.CasualChat_History(messageToDisplay));
			}
		}

		private void B_Send_Click(object sender, EventArgs e)
		{

		}

		private void AI_Casual_Chats_FormClosing(object sender, FormClosingEventArgs e)
		{
			ai.OnStreamerContentUpdated -= RefreshHistory;
		}
	}
}
