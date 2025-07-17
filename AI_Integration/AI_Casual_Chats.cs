using SuiBotAI;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Text;

namespace SSC.AI_Integration
{
	public partial class AI_Casual_Chats : Form
	{
		private static string GetFilePathPrivateConversation() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "PrivateConversation.xml");
		private bool Initializing;
		public static AI_Casual_Chats Instance { get; private set; }
		private GeminiAI ai;
		private List<GeminiMessage> messagesToDisplay;
		private GeminiContent privateMessages;
		private bool block = false;
		ChromiumWebBrowser browser = new ChromiumWebBrowser();

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
			Initializing = false;
			panel2.Controls.Add(browser);
			browser.Dock = DockStyle.Fill;
			RefreshHistory();
		}

		private void LoadPrivateConversation()
		{
			var path = GetFilePathPrivateConversation();

			if (File.Exists(path))
			{
				privateMessages = XML_Utils.Load(path, new GeminiContent()
				{
					contents = new List<GeminiMessage>(),
					StorePath = path,
				});
			}
			else
			{
				privateMessages = XML_Utils.Load(path, new GeminiContent()
				{
					contents = new List<GeminiMessage>(),
					StorePath = path,
				});
			}
		}

		private void RefreshHistory()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => { RefreshHistory(); }));
				return;
			}

			if (Initializing)
				return;
			int counter = 0;
			//chatHistory.Controls.Clear();
			if (!ai.IsConfigured())
			{
				MessageBox.Show("AI isn't properly configured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			List<GeminiMessage> messagesToDisplay = new List<GeminiMessage>();
			if (CB_PrivateChat.Checked)
			{
				for (int i = privateMessages.contents.Count - 1; i >= 0; i--)
				{
					var message = privateMessages.contents[i];
					messagesToDisplay.Add(message);
					counter++;
					if (counter >= 50)
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
					if (counter >= 50)
						break;
				}
			}

			messagesToDisplay.Reverse();
			SetBrowserData(messagesToDisplay);
		}

		private void SetBrowserData(List<GeminiMessage> messagesToDisplay)
		{
			StringBuilder sb = new StringBuilder();

		}

		private async void B_Send_Click(object sender, EventArgs e)
		{
			var text = RB_MessageToSend.Text.Trim();
			if (text.Length <= 0)
				return;
			if (block)
				return;

			block = true;

			try
			{
				if (CB_PrivateChat.Checked)
				{
					privateMessages.StorePath = GetFilePathPrivateConversation();
					await ai.GetPrivateAnswer(privateMessages, GeminiMessage.CreateMessage(AIMessageUtils.AppendDateTimePrefix(text), Role.user), false);
				}
				else
				{
					//await ai.GetSecondaryAnswer(null, null, ai.StreamerContent, text, Role.user);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				block = false;
				ClearContent();
				RefreshHistory();
			}
		}

		private void ClearContent()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new Action(() => { ClearContent(); }));
				return;
			}
			RB_MessageToSend.Text = "";
		}

		private void AI_Casual_Chats_FormClosing(object sender, FormClosingEventArgs e)
		{
			ai.OnStreamerContentUpdated -= RefreshHistory;
			browser.Dispose();
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

			if (CB_PrivateChat.Checked)
			{
				var path = GetFilePathPrivateConversation();
				privateMessages = new GeminiContent()
				{
					contents = AIMessageUtils.ImportFromGoogleFile(fileName),
					StorePath = path
				};
				XML_Utils.Save(path, privateMessages);
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
