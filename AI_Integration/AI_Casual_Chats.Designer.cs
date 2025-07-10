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
			CB_UseStreamDefinition = new System.Windows.Forms.CheckBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			B_Send = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			RB_MessageToSend = new System.Windows.Forms.RichTextBox();
			listView_Attachements = new System.Windows.Forms.ListView();
			chatHistory = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(CB_UseStreamDefinition, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
			tableLayoutPanel1.Controls.Add(chatHistory, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			tableLayoutPanel1.Size = new System.Drawing.Size(646, 474);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// CB_UseStreamDefinition
			// 
			CB_UseStreamDefinition.AutoSize = true;
			CB_UseStreamDefinition.Location = new System.Drawing.Point(3, 3);
			CB_UseStreamDefinition.Name = "CB_UseStreamDefinition";
			CB_UseStreamDefinition.Size = new System.Drawing.Size(138, 19);
			CB_UseStreamDefinition.TabIndex = 0;
			CB_UseStreamDefinition.Text = "Use stream definition";
			CB_UseStreamDefinition.UseVisualStyleBackColor = true;
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
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.7967329F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.20327F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
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
			// chatHistory
			// 
			chatHistory.ColumnCount = 1;
			chatHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			chatHistory.Dock = System.Windows.Forms.DockStyle.Fill;
			chatHistory.Location = new System.Drawing.Point(3, 29);
			chatHistory.Name = "chatHistory";
			chatHistory.RowCount = 1;
			chatHistory.RowStyles.Add(new System.Windows.Forms.RowStyle());
			chatHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			chatHistory.Size = new System.Drawing.Size(640, 314);
			chatHistory.TabIndex = 2;
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
			tableLayoutPanel1.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
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
		private System.Windows.Forms.TableLayoutPanel chatHistory;
	}
}