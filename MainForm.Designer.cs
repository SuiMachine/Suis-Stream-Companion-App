namespace SSC
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			RB_Preview = new System.Windows.Forms.RichTextBox();
			trackBar_Volume = new System.Windows.Forms.TrackBar();
			L_Volume = new System.Windows.Forms.Label();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			runBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openAIChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			connectOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			soundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			soundSettings = new System.Windows.Forms.ToolStripMenuItem();
			voiceModSettings = new System.Windows.Forms.ToolStripMenuItem();
			aIIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			askAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			streamEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			weatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			panel1 = new System.Windows.Forms.Panel();
			trayIcon = new System.Windows.Forms.NotifyIcon(components);
			trayMenu = new System.Windows.Forms.ContextMenuStrip(components);
			showProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)trackBar_Volume).BeginInit();
			menuStrip1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			trayMenu.SuspendLayout();
			SuspendLayout();
			// 
			// RB_Preview
			// 
			RB_Preview.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
			RB_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_Preview.Location = new System.Drawing.Point(4, 83);
			RB_Preview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			RB_Preview.Name = "RB_Preview";
			RB_Preview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			RB_Preview.Size = new System.Drawing.Size(523, 228);
			RB_Preview.TabIndex = 0;
			RB_Preview.Text = "";
			RB_Preview.TextChanged += RB_Preview_TextChanged;
			// 
			// trackBar_Volume
			// 
			trackBar_Volume.Dock = System.Windows.Forms.DockStyle.Top;
			trackBar_Volume.Location = new System.Drawing.Point(0, 0);
			trackBar_Volume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			trackBar_Volume.Maximum = 100;
			trackBar_Volume.Name = "trackBar_Volume";
			trackBar_Volume.Size = new System.Drawing.Size(523, 45);
			trackBar_Volume.TabIndex = 1;
			trackBar_Volume.Value = 50;
			trackBar_Volume.Scroll += TrackBar_Volume_Scroll;
			// 
			// L_Volume
			// 
			L_Volume.Anchor = System.Windows.Forms.AnchorStyles.Top;
			L_Volume.ForeColor = System.Drawing.Color.WhiteSmoke;
			L_Volume.Location = new System.Drawing.Point(205, 45);
			L_Volume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			L_Volume.Name = "L_Volume";
			L_Volume.Size = new System.Drawing.Size(117, 24);
			L_Volume.TabIndex = 2;
			L_Volume.Text = "%%";
			L_Volume.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, soundsToolStripMenuItem, aIIntegrationToolStripMenuItem, otherToolStripMenuItem, notificationToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip1.Size = new System.Drawing.Size(531, 24);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { runBotToolStripMenuItem, openAIChatToolStripMenuItem, connectOnStartupToolStripMenuItem, connectionSettingsToolStripMenuItem, exitToolStripMenuItem });
			fileToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// runBotToolStripMenuItem
			// 
			runBotToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			runBotToolStripMenuItem.CheckOnClick = true;
			runBotToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			runBotToolStripMenuItem.Name = "runBotToolStripMenuItem";
			runBotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			runBotToolStripMenuItem.Text = "Run Bot";
			runBotToolStripMenuItem.Click += RunBotToolStripMenuItem_Click;
			// 
			// openAIChatToolStripMenuItem
			// 
			openAIChatToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			openAIChatToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			openAIChatToolStripMenuItem.Name = "openAIChatToolStripMenuItem";
			openAIChatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			openAIChatToolStripMenuItem.Text = "Open AI chat";
			openAIChatToolStripMenuItem.Click += openAIChatToolStripMenuItem_Click;
			// 
			// connectOnStartupToolStripMenuItem
			// 
			connectOnStartupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			connectOnStartupToolStripMenuItem.CheckOnClick = true;
			connectOnStartupToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			connectOnStartupToolStripMenuItem.Name = "connectOnStartupToolStripMenuItem";
			connectOnStartupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			connectOnStartupToolStripMenuItem.Text = "Connect on Startup";
			connectOnStartupToolStripMenuItem.CheckedChanged += ConnectOnStartupToolStripMenuItem_CheckedChanged;
			// 
			// connectionSettingsToolStripMenuItem
			// 
			connectionSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			connectionSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
			connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			connectionSettingsToolStripMenuItem.Text = "Connection settings";
			connectionSettingsToolStripMenuItem.Click += ConnectionSettingsToolStripMenuItem_Click;
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			exitToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
			// 
			// soundsToolStripMenuItem
			// 
			soundsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { soundSettings, voiceModSettings });
			soundsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			soundsToolStripMenuItem.Name = "soundsToolStripMenuItem";
			soundsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			soundsToolStripMenuItem.Text = "&Rewards";
			// 
			// soundSettings
			// 
			soundSettings.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			soundSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
			soundSettings.Name = "soundSettings";
			soundSettings.Size = new System.Drawing.Size(180, 22);
			soundSettings.Text = "Sounds";
			soundSettings.Click += DatabaseEditorToolStripMenuItem_Click;
			// 
			// voiceModSettings
			// 
			voiceModSettings.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			voiceModSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
			voiceModSettings.Name = "voiceModSettings";
			voiceModSettings.Size = new System.Drawing.Size(180, 22);
			voiceModSettings.Text = "VoiceMod";
			voiceModSettings.Click += VoiceModSettings_Click;
			// 
			// aIIntegrationToolStripMenuItem
			// 
			aIIntegrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { askAIToolStripMenuItem, streamEventsToolStripMenuItem, weatherToolStripMenuItem });
			aIIntegrationToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			aIIntegrationToolStripMenuItem.Name = "aIIntegrationToolStripMenuItem";
			aIIntegrationToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			aIIntegrationToolStripMenuItem.Text = "&AI integration";
			// 
			// askAIToolStripMenuItem
			// 
			askAIToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			askAIToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			askAIToolStripMenuItem.Name = "askAIToolStripMenuItem";
			askAIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			askAIToolStripMenuItem.Text = "Ask AI";
			askAIToolStripMenuItem.Click += ai_askToolStripMenuItem_Click;
			// 
			// streamEventsToolStripMenuItem
			// 
			streamEventsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			streamEventsToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			streamEventsToolStripMenuItem.Name = "streamEventsToolStripMenuItem";
			streamEventsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			streamEventsToolStripMenuItem.Text = "Stream Events";
			streamEventsToolStripMenuItem.Click += ai_streamEventsToolStripMenuItem_Click;
			// 
			// weatherToolStripMenuItem
			// 
			weatherToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			weatherToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
			weatherToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			weatherToolStripMenuItem.Text = "Weather";
			weatherToolStripMenuItem.Click += weatherToolStripMenuItem_Click;
			// 
			// otherToolStripMenuItem
			// 
			otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { notesToolStripMenuItem });
			otherToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			otherToolStripMenuItem.Name = "otherToolStripMenuItem";
			otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			otherToolStripMenuItem.Text = "&Other";
			// 
			// notesToolStripMenuItem
			// 
			notesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			notesToolStripMenuItem.ForeColor = System.Drawing.Color.WhiteSmoke;
			notesToolStripMenuItem.Name = "notesToolStripMenuItem";
			notesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			notesToolStripMenuItem.Text = "Notes";
			notesToolStripMenuItem.Click += notesToolStripMenuItem_Click;
			// 
			// notificationToolStripMenuItem
			// 
			notificationToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			notificationToolStripMenuItem.Image = Properties.Resources.notification;
			notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
			notificationToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(35, 35, 35);
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(RB_Preview, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(531, 314);
			tableLayoutPanel1.TabIndex = 4;
			// 
			// panel1
			// 
			panel1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
			panel1.Controls.Add(L_Volume);
			panel1.Controls.Add(trackBar_Volume);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(4, 3);
			panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(523, 74);
			panel1.TabIndex = 0;
			// 
			// trayIcon
			// 
			trayIcon.ContextMenuStrip = trayMenu;
			trayIcon.Icon = (System.Drawing.Icon)resources.GetObject("trayIcon.Icon");
			trayIcon.Text = "Sui's Stream Companion App";
			trayIcon.Visible = true;
			trayIcon.MouseDoubleClick += TrayIcon_MouseDoubleClick;
			// 
			// trayMenu
			// 
			trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showProgramToolStripMenuItem, closeToolStripMenuItem });
			trayMenu.Name = "trayMenu";
			trayMenu.Size = new System.Drawing.Size(153, 48);
			// 
			// showProgramToolStripMenuItem
			// 
			showProgramToolStripMenuItem.Name = "showProgramToolStripMenuItem";
			showProgramToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			showProgramToolStripMenuItem.Text = "Show Program";
			showProgramToolStripMenuItem.Click += ShowProgramToolStripMenuItem_Click;
			// 
			// closeToolStripMenuItem
			// 
			closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			closeToolStripMenuItem.Text = "Close";
			closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(531, 338);
			Controls.Add(tableLayoutPanel1);
			Controls.Add(menuStrip1);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "MainForm";
			Text = "Sui's Stream Companion App";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			Resize += MainForm_Resize;
			((System.ComponentModel.ISupportInitialize)trackBar_Volume).EndInit();
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			trayMenu.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox RB_Preview;
        private System.Windows.Forms.TrackBar trackBar_Volume;
        private System.Windows.Forms.Label L_Volume;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem soundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundSettings;
        private System.Windows.Forms.ToolStripMenuItem connectOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runBotToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem voiceModSettings;
		private System.Windows.Forms.ToolStripMenuItem aIIntegrationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem askAIToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem streamEventsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem weatherToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openAIChatToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
	}
}

