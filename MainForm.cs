using SSC.Chat;
using SSC.MixItUpBridge;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace SSC
{
	public enum LineType
	{
		Generic,
		TwitchSocketCommand,
		ModCommand,
		SoundCommand,
		VoiceMod,
		WebSocket,
		GeminiAI
	}

	public partial class MainForm : Form
	{
		public static readonly MarkdownSharp.Markdown Markdown = new MarkdownSharp.Markdown();

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public static MainForm Instance { get; private set; }

		public delegate void SetPreviewTextDelegate(string text, LineType type);       //used to safely handle the IRC output from bot class
		public delegate void SetVolumeSlider(int value);       //used to safely change the slider position

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public ChatBot TwitchBot { get; private set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public EventBridge TwitchEvents { get; private set; }
		private char PrefixCharacter = '-';
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public SoundDB SoundDB { get; private set; }
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public GeminiAI AI { get; private set; }
		WebSocketsListener webSockets;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public MixItUp MixItUpWebhook { get; private set; }

		public MainForm()
		{
			Instance = this;
			TwitchEvents = new EventBridge();
			MixItUpWebhook = new MixItUp();
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var settings = PrivateSettings.GetInstance();
			webSockets = new WebSocketsListener();
			AI = new GeminiAI();
			UpdateColors();
			connectOnStartupToolStripMenuItem.Checked = settings.Autostart;
			int valrr = Convert.ToInt32(100 * settings.Volume);
			trackBar_Volume.Value = valrr;
			L_Volume.Text = trackBar_Volume.Value.ToString() + "%";
			SoundDB = new SoundDB();

			if (settings.Autostart)
			{
				StartBot();
			}

			if (settings.RunWebSocketsServer)
				webSockets.Start();
		}

		private void StartBot()
		{
			TwitchBot = new ChatBot(SoundDB, PrefixCharacter);
			TwitchBot.Connect();
			if (AI.IsConfigured())
			{
				AI.Register();
			}
		}

		#region ThreadSafeFunctions
		private void AddPreviewText(string text, LineType type)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.RB_Preview.InvokeRequired)
			{
				SetPreviewTextDelegate d = new SetPreviewTextDelegate(AddPreviewText);
				this.Invoke(d, new object[] { text, type });
			}
			else
			{
				var settings = PrivateSettings.GetInstance();
				RB_Preview.AppendText(text + "\n");
				RB_Preview.Select(RB_Preview.Text.Length - text.Length - 1, text.Length);

				switch (type)
				{
					case LineType.Generic:
						RB_Preview.SelectionColor = settings.Colors.LineColorGeneric;
						break;
					case LineType.TwitchSocketCommand:
						RB_Preview.SelectionColor = settings.Colors.LineColorIrcCommand;
						break;
					case LineType.ModCommand:
						RB_Preview.SelectionColor = settings.Colors.LineColorModeration;
						break;
					case LineType.SoundCommand:
						RB_Preview.SelectionColor = settings.Colors.LineColorSoundPlayback;
						break;
					case LineType.WebSocket:
						RB_Preview.SelectionColor = settings.Colors.LineColorWebSocket;
						break;
					default:
						RB_Preview.SelectionColor = settings.Colors.LineColorGeneric;
						break;

				}
			}
		}

		public void ThreadSafeAddPreviewText(string text, LineType type)
		{
			this.AddPreviewText(text, type);
		}

		public void SetVolume(int value)
		{
			if (this.trackBar_Volume.InvokeRequired)
			{
				SetVolumeSlider d = new SetVolumeSlider(SetVolume);
				this.Invoke(d, new object[] { value });
			}
			else
			{
				trackBar_Volume.Value = value;
				L_Volume.Text = trackBar_Volume.Value.ToString() + "%";
			}
		}

		public int GetVolume() => trackBar_Volume.Value;

		private void PerformShutdownTasks()
		{
			if (TwitchBot != null)
				TwitchBot.StopBot();
			trayIcon.Visible = false;
			var settings = PrivateSettings.GetInstance();
			settings.SaveSettings();
			this.webSockets.Stop();

			System.Environment.Exit(0);
		}
		#endregion

		#region EventHandlers
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			PerformShutdownTasks();
		}

		private void RB_Preview_TextChanged(object sender, EventArgs e)
		{
			RB_Preview.SelectionStart = RB_Preview.Text.Length;
			RB_Preview.ScrollToCaret();
		}

		private void TrackBar_Volume_Scroll(object sender, EventArgs e)
		{
			L_Volume.Text = trackBar_Volume.Value.ToString() + "%";
			var settings = PrivateSettings.GetInstance();

			settings.Volume = trackBar_Volume.Value / 100f;
			if (TwitchBot != null)
				TwitchBot.UpdateVolume();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				trayIcon.Visible = true;
				this.Hide();
			}
			else if (this.WindowState == FormWindowState.Normal)
			{
				trayIcon.Visible = false;
				this.Show();
			}
		}

		#region FileTree_Events
		private void RunBotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var CastedSender = (ToolStripMenuItem)sender;
			if (CastedSender.Checked)
			{
				StartBot();
			}
			else
			{
				StopBot();
			}
		}

		private void ConnectOnStartupToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			var CastedSender = (ToolStripMenuItem)sender;
			var settings = PrivateSettings.GetInstance();

			settings.Autostart = CastedSender.Checked;
			settings.SaveSettings();
		}

		private void ConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SettingsForms.ConnectionSettingsForm form = new SettingsForms.ConnectionSettingsForm(this);
			var settings = PrivateSettings.GetInstance();

			DialogResult res = form.ShowDialog();
			if (res == DialogResult.OK)
			{
				settings.UserAuth = form.UserAuth;
				settings.BotAuth = form.BotAuth;
				settings.Debug_mode = form.DebugMode;
				settings.WebSocketsServerPort = form.WebsocketPort;
				settings.RunWebSocketsServer = form.RunWebsocket;
				settings.MixItUpWebookURL = form.MixItUp_WebookURL;
				settings.SaveSettings();
				ReloadBot();
			}
		}

		private void ReloadBot()
		{
			webSockets.Stop();
			if (PrivateSettings.GetInstance().RunWebSocketsServer)
				webSockets.Start();

			if (TwitchBot != null && TwitchBot.BotRunning)
				StopBot();

			StartBot();
		}

		private void StopBot()
		{
			if (TwitchBot != null && TwitchBot.BotRunning)
			{
				TwitchBot.StopBot();
			}

			TwitchBot = null;

			if (AI != null)
				AI.Unregister();
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.StopBot();
			this.webSockets.Stop();
			this.Close();
		}
		#endregion

		#region TrayIcon_Events
		private void ShowProgramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}

		private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}
		#endregion
		#endregion

		#region ColorThemeOverrideFunctions
		private void UpdateColors()
		{
			var settings = PrivateSettings.GetInstance();

			var CustomColorTable = new Extensions.OverridenColorTable()
			{
				UseSystemColors = false,
				ColorMenuBorder = Color.Black,
				ColorMenuBarBackground = settings.Colors.MenuStripBarBackground,
				ColorMenuItemSelected = settings.Colors.MenuStripBackgroundSelected,
				ColorMenuBackground = settings.Colors.MenuStripBackground,

				TextColor = settings.Colors.MenuStripText
			};

			this.BackColor = settings.Colors.FormBackground;
			this.ForeColor = settings.Colors.FormTextColor;
			menuStrip1.Renderer = new ToolStripProfessionalRenderer(CustomColorTable);
			menuStrip1.ForeColor = settings.Colors.MenuStripBarText;
			ReColorChildren(menuStrip1);

			RB_Preview.BackColor = settings.Colors.LineColorBackground;
			RB_Preview.Clear();
		}

		private void ReColorChildren(MenuStrip menuStrip1)
		{
			var settings = PrivateSettings.GetInstance();


			for (int i = 0; i < menuStrip1.Items.Count; i++)
			{
				if (menuStrip1.Items[1].GetType() == typeof(ToolStripMenuItem))
				{
					var TempCast = (ToolStripMenuItem)menuStrip1.Items[i];
					foreach (ToolStripItem child in TempCast.DropDownItems)
					{
						child.BackColor = settings.Colors.MenuStripBackground;
						child.ForeColor = settings.Colors.MenuStripText;
					}
				}
			}
		}
		#endregion

		private void DatabaseEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SoundDatabaseEditor.DB_Editor scf = new SoundDatabaseEditor.DB_Editor(SoundDB.SoundList);
			DialogResult res = scf.ShowDialog();
			if (res == DialogResult.OK)
			{
				SoundDB.SoundList = scf.SoundsCopy;
				SoundDB.Save();
			}
		}

		private void VoiceModSettings_Click(object sender, EventArgs e)
		{
			SettingsForms.VoiceModIntegrationForm form = new SettingsForms.VoiceModIntegrationForm();
			var result = form.ShowDialog();
			if (result == DialogResult.OK)
			{

			}
		}

		private void ai_askToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AI_Integration.AskAI_Configuration_Form ai_form = new AI_Integration.AskAI_Configuration_Form();
			var result = ai_form.ShowDialog();
			if (result == DialogResult.OK)
			{
			}
		}

		private void ai_streamEventsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AI_Integration.AI_StreamEvents ai_form = new AI_Integration.AI_StreamEvents();
			var result = ai_form.ShowDialog();
			if (result == DialogResult.OK)
			{

			}
		}

		private void weatherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AI_Integration.AI_Weather_Setting weather = new AI_Integration.AI_Weather_Setting();
			var result = weather.ShowDialog();
			if (result == DialogResult.OK)
			{
				//Nothing?
			}
		}

		private void openAIChatToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AI_Integration.AI_Casual_Chats chats = new AI_Integration.AI_Casual_Chats(AI);
			chats.Show();
		}
	}
}
