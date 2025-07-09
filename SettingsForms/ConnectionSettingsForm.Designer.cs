namespace SSC.SettingsForms
{
    partial class ConnectionSettingsForm
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
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			panel1 = new System.Windows.Forms.Panel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			CB_ShowPasswordUser = new System.Windows.Forms.CheckBox();
			button1 = new System.Windows.Forms.Button();
			CB_ShowBotAuth = new System.Windows.Forms.CheckBox();
			B_GetLoginData = new System.Windows.Forms.Button();
			tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			label6 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			Num_PortUsed = new System.Windows.Forms.NumericUpDown();
			CB_Websocket = new System.Windows.Forms.CheckBox();
			CB_DebugMode = new System.Windows.Forms.CheckBox();
			tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			label3 = new System.Windows.Forms.Label();
			TB_UserAuth = new System.Windows.Forms.TextBox();
			label8 = new System.Windows.Forms.Label();
			TB_BotAuth = new System.Windows.Forms.TextBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			B_Save = new System.Windows.Forms.Button();
			B_Cancel = new System.Windows.Forms.Button();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			TB_MixItUpWebhook = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel9.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Num_PortUsed).BeginInit();
			tableLayoutPanel8.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(656, 232);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(tableLayoutPanel3);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(4, 3);
			panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(648, 135);
			panel1.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(tableLayoutPanel9, 0, 2);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 0);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel8, 0, 1);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 4;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel3.Size = new System.Drawing.Size(648, 135);
			tableLayoutPanel3.TabIndex = 25;
			// 
			// tableLayoutPanel9
			// 
			tableLayoutPanel9.ColumnCount = 4;
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146F));
			tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel9.Controls.Add(CB_ShowPasswordUser, 1, 0);
			tableLayoutPanel9.Controls.Add(button1, 2, 0);
			tableLayoutPanel9.Controls.Add(CB_ShowBotAuth, 3, 0);
			tableLayoutPanel9.Controls.Add(B_GetLoginData, 0, 0);
			tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel9.Location = new System.Drawing.Point(4, 85);
			tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel9.Name = "tableLayoutPanel9";
			tableLayoutPanel9.RowCount = 1;
			tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel9.Size = new System.Drawing.Size(640, 44);
			tableLayoutPanel9.TabIndex = 5;
			// 
			// CB_ShowPasswordUser
			// 
			CB_ShowPasswordUser.AutoSize = true;
			CB_ShowPasswordUser.Dock = System.Windows.Forms.DockStyle.Fill;
			CB_ShowPasswordUser.Location = new System.Drawing.Point(164, 3);
			CB_ShowPasswordUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CB_ShowPasswordUser.Name = "CB_ShowPasswordUser";
			CB_ShowPasswordUser.Size = new System.Drawing.Size(159, 38);
			CB_ShowPasswordUser.TabIndex = 10;
			CB_ShowPasswordUser.Text = "Show user auth";
			CB_ShowPasswordUser.UseVisualStyleBackColor = true;
			CB_ShowPasswordUser.CheckedChanged += CB_ShowPassword_CheckedChanged;
			// 
			// button1
			// 
			button1.Dock = System.Windows.Forms.DockStyle.Fill;
			button1.Location = new System.Drawing.Point(331, 3);
			button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(138, 38);
			button1.TabIndex = 24;
			button1.Text = "Obtain auth (manual)";
			button1.UseVisualStyleBackColor = true;
			button1.Click += B_GetLoginDataManual_Click;
			// 
			// CB_ShowBotAuth
			// 
			CB_ShowBotAuth.AutoSize = true;
			CB_ShowBotAuth.Dock = System.Windows.Forms.DockStyle.Fill;
			CB_ShowBotAuth.Location = new System.Drawing.Point(477, 3);
			CB_ShowBotAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CB_ShowBotAuth.Name = "CB_ShowBotAuth";
			CB_ShowBotAuth.Size = new System.Drawing.Size(159, 38);
			CB_ShowBotAuth.TabIndex = 22;
			CB_ShowBotAuth.Text = "Show bot auth";
			CB_ShowBotAuth.UseVisualStyleBackColor = true;
			CB_ShowBotAuth.CheckedChanged += CB_ShowBotAuth_CheckedChanged;
			// 
			// B_GetLoginData
			// 
			B_GetLoginData.Dock = System.Windows.Forms.DockStyle.Fill;
			B_GetLoginData.Location = new System.Drawing.Point(4, 3);
			B_GetLoginData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_GetLoginData.Name = "B_GetLoginData";
			B_GetLoginData.Size = new System.Drawing.Size(152, 38);
			B_GetLoginData.TabIndex = 11;
			B_GetLoginData.Text = "Obtain auth (webserver)";
			B_GetLoginData.UseVisualStyleBackColor = true;
			B_GetLoginData.Click += B_GetLoginData_Click;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.ColumnCount = 5;
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 616F));
			tableLayoutPanel6.Controls.Add(label6, 2, 0);
			tableLayoutPanel6.Controls.Add(label4, 0, 0);
			tableLayoutPanel6.Controls.Add(Num_PortUsed, 3, 0);
			tableLayoutPanel6.Controls.Add(CB_Websocket, 1, 0);
			tableLayoutPanel6.Controls.Add(CB_DebugMode, 4, 0);
			tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel6.Location = new System.Drawing.Point(4, 3);
			tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.Size = new System.Drawing.Size(640, 35);
			tableLayoutPanel6.TabIndex = 2;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Dock = System.Windows.Forms.DockStyle.Fill;
			label6.Location = new System.Drawing.Point(254, 0);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(110, 35);
			label6.TabIndex = 15;
			label6.Text = "Websocket port:";
			label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Dock = System.Windows.Forms.DockStyle.Left;
			label4.Location = new System.Drawing.Point(4, 0);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(65, 35);
			label4.TabIndex = 23;
			label4.Text = "Websocket";
			label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Num_PortUsed
			// 
			Num_PortUsed.Location = new System.Drawing.Point(372, 3);
			Num_PortUsed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Num_PortUsed.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
			Num_PortUsed.Minimum = new decimal(new int[] { 8000, 0, 0, 0 });
			Num_PortUsed.Name = "Num_PortUsed";
			Num_PortUsed.Size = new System.Drawing.Size(100, 23);
			Num_PortUsed.TabIndex = 17;
			Num_PortUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			Num_PortUsed.Value = new decimal(new int[] { 8000, 0, 0, 0 });
			// 
			// CB_Websocket
			// 
			CB_Websocket.AutoSize = true;
			CB_Websocket.Dock = System.Windows.Forms.DockStyle.Fill;
			CB_Websocket.Location = new System.Drawing.Point(92, 3);
			CB_Websocket.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CB_Websocket.Name = "CB_Websocket";
			CB_Websocket.Size = new System.Drawing.Size(154, 29);
			CB_Websocket.TabIndex = 13;
			CB_Websocket.Text = "Run websocket server";
			CB_Websocket.UseVisualStyleBackColor = true;
			// 
			// CB_DebugMode
			// 
			CB_DebugMode.AutoSize = true;
			CB_DebugMode.Dock = System.Windows.Forms.DockStyle.Fill;
			CB_DebugMode.Location = new System.Drawing.Point(482, 3);
			CB_DebugMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CB_DebugMode.Name = "CB_DebugMode";
			CB_DebugMode.Size = new System.Drawing.Size(608, 29);
			CB_DebugMode.TabIndex = 12;
			CB_DebugMode.Text = "Debug mode";
			CB_DebugMode.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel8
			// 
			tableLayoutPanel8.ColumnCount = 4;
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.79012F));
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.20988F));
			tableLayoutPanel8.Controls.Add(label3, 0, 0);
			tableLayoutPanel8.Controls.Add(TB_UserAuth, 1, 0);
			tableLayoutPanel8.Controls.Add(label8, 2, 0);
			tableLayoutPanel8.Controls.Add(TB_BotAuth, 3, 0);
			tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel8.Location = new System.Drawing.Point(4, 44);
			tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel8.Name = "tableLayoutPanel8";
			tableLayoutPanel8.RowCount = 1;
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel8.Size = new System.Drawing.Size(640, 35);
			tableLayoutPanel8.TabIndex = 4;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Dock = System.Windows.Forms.DockStyle.Fill;
			label3.Location = new System.Drawing.Point(4, 0);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(104, 35);
			label3.TabIndex = 3;
			label3.Text = "Owner auth:";
			label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TB_UserAuth
			// 
			TB_UserAuth.Dock = System.Windows.Forms.DockStyle.Fill;
			TB_UserAuth.Location = new System.Drawing.Point(116, 3);
			TB_UserAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TB_UserAuth.Name = "TB_UserAuth";
			TB_UserAuth.Size = new System.Drawing.Size(236, 23);
			TB_UserAuth.TabIndex = 6;
			TB_UserAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			TB_UserAuth.UseSystemPasswordChar = true;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Dock = System.Windows.Forms.DockStyle.Fill;
			label8.Location = new System.Drawing.Point(360, 0);
			label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(90, 35);
			label8.TabIndex = 20;
			label8.Text = "Bot auth:";
			label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// TB_BotAuth
			// 
			TB_BotAuth.Dock = System.Windows.Forms.DockStyle.Fill;
			TB_BotAuth.Location = new System.Drawing.Point(458, 3);
			TB_BotAuth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TB_BotAuth.Name = "TB_BotAuth";
			TB_BotAuth.Size = new System.Drawing.Size(178, 23);
			TB_BotAuth.TabIndex = 21;
			TB_BotAuth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			TB_BotAuth.UseSystemPasswordChar = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.Controls.Add(B_Save, 0, 0);
			tableLayoutPanel2.Controls.Add(B_Cancel, 1, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(4, 187);
			tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			tableLayoutPanel2.Size = new System.Drawing.Size(648, 43);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// B_Save
			// 
			B_Save.Dock = System.Windows.Forms.DockStyle.Right;
			B_Save.Location = new System.Drawing.Point(232, 3);
			B_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_Save.Name = "B_Save";
			B_Save.Size = new System.Drawing.Size(88, 37);
			B_Save.TabIndex = 0;
			B_Save.Text = "Save";
			B_Save.UseVisualStyleBackColor = true;
			B_Save.Click += B_Save_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
			B_Cancel.Location = new System.Drawing.Point(328, 3);
			B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(88, 37);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.Controls.Add(TB_MixItUpWebhook, 1, 0);
			tableLayoutPanel4.Controls.Add(label1, 0, 0);
			tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel4.Location = new System.Drawing.Point(4, 144);
			tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.Size = new System.Drawing.Size(648, 37);
			tableLayoutPanel4.TabIndex = 2;
			// 
			// TB_MixItUpWebhook
			// 
			TB_MixItUpWebhook.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_MixItUpWebhook.Location = new System.Drawing.Point(152, 7);
			TB_MixItUpWebhook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TB_MixItUpWebhook.Name = "TB_MixItUpWebhook";
			TB_MixItUpWebhook.Size = new System.Drawing.Size(492, 23);
			TB_MixItUpWebhook.TabIndex = 7;
			TB_MixItUpWebhook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 11);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(140, 15);
			label1.TabIndex = 4;
			label1.Text = "MixItUp Webook URL*";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ConnectionSettingsForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(656, 232);
			Controls.Add(tableLayoutPanel1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(1192, 271);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(672, 271);
			Name = "ConnectionSettingsForm";
			Text = "Connection Settings";
			tableLayoutPanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel9.ResumeLayout(false);
			tableLayoutPanel9.PerformLayout();
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)Num_PortUsed).EndInit();
			tableLayoutPanel8.ResumeLayout(false);
			tableLayoutPanel8.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TB_UserAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox CB_ShowPasswordUser;
        private System.Windows.Forms.Button B_GetLoginData;
		private System.Windows.Forms.CheckBox CB_DebugMode;
		private System.Windows.Forms.CheckBox CB_Websocket;
		private System.Windows.Forms.CheckBox CB_ShowBotAuth;
		private System.Windows.Forms.TextBox TB_BotAuth;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown Num_PortUsed;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TB_MixItUpWebhook;
	}
}