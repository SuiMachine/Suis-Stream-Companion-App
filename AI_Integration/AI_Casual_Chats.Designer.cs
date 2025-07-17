namespace SSC.AI_Integration
{
	partial class AI_Casual_Chats
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
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			B_Send = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			RB_MessageToSend = new System.Windows.Forms.RichTextBox();
			listView_Attachements = new System.Windows.Forms.ListView();
			panel1 = new System.Windows.Forms.Panel();
			B_ImportHistory = new System.Windows.Forms.Button();
			CB_PrivateChat = new System.Windows.Forms.CheckBox();
			CB_UseStreamDefinition = new System.Windows.Forms.CheckBox();
			panel2 = new System.Windows.Forms.Panel();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(panel2, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			tableLayoutPanel1.Size = new System.Drawing.Size(646, 474);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
			tableLayoutPanel2.Controls.Add(listView_Attachements, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 349);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(640, 122);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 3;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 65F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			tableLayoutPanel3.Controls.Add(B_Send, 2, 0);
			tableLayoutPanel3.Controls.Add(label1, 0, 0);
			tableLayoutPanel3.Controls.Add(RB_MessageToSend, 1, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 87);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(634, 32);
			tableLayoutPanel3.TabIndex = 0;
			// 
			// B_Send
			// 
			B_Send.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_Send.Location = new System.Drawing.Point(554, 4);
			B_Send.Name = "B_Send";
			B_Send.Size = new System.Drawing.Size(77, 23);
			B_Send.TabIndex = 0;
			B_Send.Text = "Send";
			B_Send.UseVisualStyleBackColor = true;
			B_Send.Click += B_Send_Click;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 8);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(56, 15);
			label1.TabIndex = 1;
			label1.Text = "Message:";
			// 
			// RB_MessageToSend
			// 
			RB_MessageToSend.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_MessageToSend.Location = new System.Drawing.Point(68, 3);
			RB_MessageToSend.Name = "RB_MessageToSend";
			RB_MessageToSend.Size = new System.Drawing.Size(480, 26);
			RB_MessageToSend.TabIndex = 2;
			RB_MessageToSend.Text = "";
			// 
			// listView_Attachements
			// 
			listView_Attachements.Dock = System.Windows.Forms.DockStyle.Fill;
			listView_Attachements.Location = new System.Drawing.Point(3, 3);
			listView_Attachements.Name = "listView_Attachements";
			listView_Attachements.Size = new System.Drawing.Size(634, 78);
			listView_Attachements.TabIndex = 1;
			listView_Attachements.UseCompatibleStateImageBehavior = false;
			// 
			// panel1
			// 
			panel1.Controls.Add(B_ImportHistory);
			panel1.Controls.Add(CB_PrivateChat);
			panel1.Controls.Add(CB_UseStreamDefinition);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(640, 27);
			panel1.TabIndex = 3;
			// 
			// B_ImportHistory
			// 
			B_ImportHistory.Location = new System.Drawing.Point(243, 3);
			B_ImportHistory.Name = "B_ImportHistory";
			B_ImportHistory.Size = new System.Drawing.Size(97, 23);
			B_ImportHistory.TabIndex = 2;
			B_ImportHistory.Text = "Import history";
			B_ImportHistory.UseVisualStyleBackColor = true;
			B_ImportHistory.Click += B_ImportHistory_Click;
			// 
			// CB_PrivateChat
			// 
			CB_PrivateChat.AutoSize = true;
			CB_PrivateChat.Location = new System.Drawing.Point(147, 6);
			CB_PrivateChat.Name = "CB_PrivateChat";
			CB_PrivateChat.Size = new System.Drawing.Size(90, 19);
			CB_PrivateChat.TabIndex = 1;
			CB_PrivateChat.Text = "Private Chat";
			CB_PrivateChat.UseVisualStyleBackColor = true;
			CB_PrivateChat.CheckedChanged += CB_PrivateChat_CheckedChanged;
			// 
			// CB_UseStreamDefinition
			// 
			CB_UseStreamDefinition.AutoSize = true;
			CB_UseStreamDefinition.Location = new System.Drawing.Point(3, 6);
			CB_UseStreamDefinition.Name = "CB_UseStreamDefinition";
			CB_UseStreamDefinition.Size = new System.Drawing.Size(138, 19);
			CB_UseStreamDefinition.TabIndex = 0;
			CB_UseStreamDefinition.Text = "Use stream definition";
			CB_UseStreamDefinition.UseVisualStyleBackColor = true;
			CB_UseStreamDefinition.CheckedChanged += CB_UseStreamDefinition_CheckedChanged;
			// 
			// panel2
			// 
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(3, 36);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(640, 307);
			panel2.TabIndex = 4;
			// 
			// AI_Casual_Chats
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(646, 474);
			Controls.Add(tableLayoutPanel1);
			MinimumSize = new System.Drawing.Size(640, 480);
			Name = "AI_Casual_Chats";
			Text = "AI Casual Chats";
			FormClosing += AI_Casual_Chats_FormClosing;
			Load += AI_Casual_Chats_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.CheckBox CB_UseStreamDefinition;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button B_Send;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox RB_MessageToSend;
		private System.Windows.Forms.ListView listView_Attachements;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox CB_PrivateChat;
		private System.Windows.Forms.Button B_ImportHistory;
		private System.Windows.Forms.Panel panel2;
	}
}