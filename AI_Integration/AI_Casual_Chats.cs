using SuiBotAI;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SSC.AI_Integration
{
	public partial class AI_Casual_Chats : Form
	{
		private static string GetFilePathPrivateConversation() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "PrivateConversation.xml");
		private bool Initializing;
		public static AI_Casual_Chats Instance { get; private set; }
		private GeminiAI ai;
		private List<GeminiMessage> messagesToDisplay;
		private List<GeminiMessage> privateMessages;


		public AI_Casual_Chats(GeminiAI ai)
		{
			Initializing = true;
			InitializeComponent();
			this.ai = ai;
		}

		private void AI_Casual_Chats_Load(object sender, EventArgs e)
		{
			CB_UseStreamDefinition.Checked = AIConfig.GetInstance().CasualChat_StreamDefinition;
			CB_PrivateChat.Checked = AIConfig.GetInstance().CasualChat_PrivateConversation;
			if (!CB_PrivateChat.Checked)
				ai.OnStreamerContentUpdated += RefreshHistory;

			LoadPrivateConversation();
			RefreshHistory();
			Initializing = false;
		}

		private void LoadPrivateConversation()
		{
			var path = GetFilePathPrivateConversation();

			if(File.Exists(path))
			{
				privateMessages = XML_Utils.Load(path, new List<GeminiMessage>());
			}
			else
				privateMessages = new List<GeminiMessage>();
		}

		private void RefreshHistory()
		{
			if (Initializing)
				return;
			int counter = 0;
			chatHistory.Controls.Clear();
			if (!ai.IsConfigured())
			{
				MessageBox.Show("AI isn't properly configured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			List<GeminiMessage> messagesToDisplay = new List<GeminiMessage>();
			if(CB_PrivateChat.Checked)
			{
				for (int i = privateMessages.Count - 1; i >= 0; i--)
				{
					var message = privateMessages[i];
					messagesToDisplay.Add(message);
					counter++;
					if (counter >= 25)
						break;
				}
			}
			else
			{
				for (int i = ai.StreamerContent.contents.Count - 1; i >= 0; i--)
				{
					var message = ai.StreamerContent.contents[i];
					messagesToDisplay.Add(message);
					counter++;
					if (counter >= 25)
						break;
				}
			}


			messagesToDisplay.Reverse();
			chatHistory.RowCount = messagesToDisplay.Count;
			chatHistory.AutoScroll = true;
			foreach (var messageToDisplay in messagesToDisplay)
			{
				chatHistory.Controls.Add(new CasualChatsElements.CasualChat_History(messageToDisplay)
				{
					Dock = DockStyle.Fill,
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowOnly,
				});
			}
		}

		private void B_Send_Click(object sender, EventArgs e)
		{

		}

		private void AI_Casual_Chats_FormClosing(object sender, FormClosingEventArgs e)
		{
			ai.OnStreamerContentUpdated -= RefreshHistory;
		}

		private void B_ImportHistory_Click(object sender, EventArgs e)
		{
			var message = new UniversalMessageBox("Import from:", "Google", "XML", "Cancel");
			var result = message.ShowDialog();
			if (result == DialogResult.Cancel || message.Option == 3)
				return;

			if (message.Option == 1)
			{
				var f = new OpenFileDialog()
				{
					CheckFileExists = true,
					ShowHelp = true,
					Filter = "Google history file|*.*"
				};
				result = f.ShowDialog();
				if (result == DialogResult.OK)
					ImportFromGoogleFile(f.FileName);
			}
			else
			{

			}
		}

		private void ImportFromGoogleFile(string fileName)
		{
			if (MessageBox.Show("Warning, you are about to override a current history. Do you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;

			if(CB_PrivateChat.Checked)
			{
				privateMessages = AIMessageUtils.ImportFromGoogleFile(fileName);
				XML_Utils.Save(GetFilePathPrivateConversation(), privateMessages);
			}
			else
			{

			}
		}

		private void CB_UseStreamDefinition_CheckedChanged(object sender, EventArgs e)
		{
			AIConfig.GetInstance().CasualChat_StreamDefinition = CB_UseStreamDefinition.Checked;
			AIConfig.GetInstance().SaveSettings();
		}

		private void CB_PrivateChat_CheckedChanged(object sender, EventArgs e)
		{
			AIConfig.GetInstance().CasualChat_PrivateConversation = CB_PrivateChat.Checked;
			RefreshHistory();
			if (CB_PrivateChat.Checked)
				ai.OnStreamerContentUpdated -= RefreshHistory;
			else
				ai.OnStreamerContentUpdated += RefreshHistory;
			AIConfig.GetInstance().SaveSettings();
		}
	}
}
