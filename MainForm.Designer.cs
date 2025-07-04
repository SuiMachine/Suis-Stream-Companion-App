﻿namespace SSC
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.RB_Preview = new System.Windows.Forms.RichTextBox();
			this.trackBar_Volume = new System.Windows.Forms.TrackBar();
			this.L_Volume = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.connectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.soundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.soundSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.voiceModSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.aIIntegrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.askAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.streamEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.weatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.trayMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// RB_Preview
			// 
			this.RB_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RB_Preview.Location = new System.Drawing.Point(3, 72);
			this.RB_Preview.Name = "RB_Preview";
			this.RB_Preview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.RB_Preview.Size = new System.Drawing.Size(449, 194);
			this.RB_Preview.TabIndex = 0;
			this.RB_Preview.Text = "";
			this.RB_Preview.TextChanged += new System.EventHandler(this.RB_Preview_TextChanged);
			// 
			// trackBar_Volume
			// 
			this.trackBar_Volume.Dock = System.Windows.Forms.DockStyle.Top;
			this.trackBar_Volume.Location = new System.Drawing.Point(0, 0);
			this.trackBar_Volume.Maximum = 100;
			this.trackBar_Volume.Name = "trackBar_Volume";
			this.trackBar_Volume.Size = new System.Drawing.Size(449, 45);
			this.trackBar_Volume.TabIndex = 1;
			this.trackBar_Volume.Value = 50;
			this.trackBar_Volume.Scroll += new System.EventHandler(this.TrackBar_Volume_Scroll);
			// 
			// L_Volume
			// 
			this.L_Volume.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.L_Volume.Location = new System.Drawing.Point(177, 39);
			this.L_Volume.Name = "L_Volume";
			this.L_Volume.Size = new System.Drawing.Size(100, 21);
			this.L_Volume.TabIndex = 2;
			this.L_Volume.Text = "%%";
			this.L_Volume.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.soundsToolStripMenuItem,
            this.aIIntegrationToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(455, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runBotToolStripMenuItem,
            this.connectOnStartupToolStripMenuItem,
            this.connectionSettingsToolStripMenuItem,
            this.colorSettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// runBotToolStripMenuItem
			// 
			this.runBotToolStripMenuItem.CheckOnClick = true;
			this.runBotToolStripMenuItem.Name = "runBotToolStripMenuItem";
			this.runBotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.runBotToolStripMenuItem.Text = "Run Bot";
			this.runBotToolStripMenuItem.Click += new System.EventHandler(this.RunBotToolStripMenuItem_Click);
			// 
			// connectOnStartupToolStripMenuItem
			// 
			this.connectOnStartupToolStripMenuItem.CheckOnClick = true;
			this.connectOnStartupToolStripMenuItem.Name = "connectOnStartupToolStripMenuItem";
			this.connectOnStartupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.connectOnStartupToolStripMenuItem.Text = "Connect on Startup";
			this.connectOnStartupToolStripMenuItem.CheckedChanged += new System.EventHandler(this.ConnectOnStartupToolStripMenuItem_CheckedChanged);
			// 
			// connectionSettingsToolStripMenuItem
			// 
			this.connectionSettingsToolStripMenuItem.Name = "connectionSettingsToolStripMenuItem";
			this.connectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.connectionSettingsToolStripMenuItem.Text = "Connection settings";
			this.connectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.ConnectionSettingsToolStripMenuItem_Click);
			// 
			// colorSettingsToolStripMenuItem
			// 
			this.colorSettingsToolStripMenuItem.Name = "colorSettingsToolStripMenuItem";
			this.colorSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.colorSettingsToolStripMenuItem.Text = "Color settings";
			this.colorSettingsToolStripMenuItem.Click += new System.EventHandler(this.ColorSettingsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// soundsToolStripMenuItem
			// 
			this.soundsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundSettings,
            this.voiceModSettings});
			this.soundsToolStripMenuItem.Name = "soundsToolStripMenuItem";
			this.soundsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.soundsToolStripMenuItem.Text = "Rewards";
			// 
			// soundSettings
			// 
			this.soundSettings.Name = "soundSettings";
			this.soundSettings.Size = new System.Drawing.Size(127, 22);
			this.soundSettings.Text = "Sounds";
			this.soundSettings.Click += new System.EventHandler(this.DatabaseEditorToolStripMenuItem_Click);
			// 
			// voiceModSettings
			// 
			this.voiceModSettings.Name = "voiceModSettings";
			this.voiceModSettings.Size = new System.Drawing.Size(127, 22);
			this.voiceModSettings.Text = "VoiceMod";
			this.voiceModSettings.Click += new System.EventHandler(this.VoiceModSettings_Click);
			// 
			// aIIntegrationToolStripMenuItem
			// 
			this.aIIntegrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.askAIToolStripMenuItem,
            this.streamEventsToolStripMenuItem,
            this.weatherToolStripMenuItem});
			this.aIIntegrationToolStripMenuItem.Name = "aIIntegrationToolStripMenuItem";
			this.aIIntegrationToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.aIIntegrationToolStripMenuItem.Text = "AI integration";
			// 
			// askAIToolStripMenuItem
			// 
			this.askAIToolStripMenuItem.Name = "askAIToolStripMenuItem";
			this.askAIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.askAIToolStripMenuItem.Text = "Ask AI";
			this.askAIToolStripMenuItem.Click += new System.EventHandler(this.ai_askToolStripMenuItem_Click);
			// 
			// streamEventsToolStripMenuItem
			// 
			this.streamEventsToolStripMenuItem.Name = "streamEventsToolStripMenuItem";
			this.streamEventsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.streamEventsToolStripMenuItem.Text = "Stream Events";
			this.streamEventsToolStripMenuItem.Click += new System.EventHandler(this.ai_streamEventsToolStripMenuItem_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.RB_Preview, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 269);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.L_Volume);
			this.panel1.Controls.Add(this.trackBar_Volume);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(449, 63);
			this.panel1.TabIndex = 0;
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayMenu;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "Sui\'s Stream Companion App";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
			// 
			// trayMenu
			// 
			this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showProgramToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.trayMenu.Name = "trayMenu";
			this.trayMenu.Size = new System.Drawing.Size(153, 48);
			// 
			// showProgramToolStripMenuItem
			// 
			this.showProgramToolStripMenuItem.Name = "showProgramToolStripMenuItem";
			this.showProgramToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showProgramToolStripMenuItem.Text = "Show Program";
			this.showProgramToolStripMenuItem.Click += new System.EventHandler(this.ShowProgramToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
			// 
			// weatherToolStripMenuItem
			// 
			this.weatherToolStripMenuItem.Name = "weatherToolStripMenuItem";
			this.weatherToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.weatherToolStripMenuItem.Text = "Weather";
			this.weatherToolStripMenuItem.Click += new System.EventHandler(this.weatherToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 293);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Sui\'s Stream Companion App";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Volume)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.trayMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem colorSettingsToolStripMenuItem;
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
	}
}

