namespace SSC.AI_Integration.CasualChatsElements
{
	partial class EditDisplay
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
			B_Save = new System.Windows.Forms.Button();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			pic_AI = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			TB_UserIcon = new System.Windows.Forms.TextBox();
			TB_AIIcon = new System.Windows.Forms.TextBox();
			B_BrowseUser = new System.Windows.Forms.Button();
			B_BrowseAI = new System.Windows.Forms.Button();
			pic_User = new System.Windows.Forms.PictureBox();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pic_AI).BeginInit();
			((System.ComponentModel.ISupportInitialize)pic_User).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(B_Save, 0, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			tableLayoutPanel1.Size = new System.Drawing.Size(569, 229);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// B_Save
			// 
			B_Save.Anchor = System.Windows.Forms.AnchorStyles.Right;
			B_Save.Location = new System.Drawing.Point(491, 200);
			B_Save.Name = "B_Save";
			B_Save.Size = new System.Drawing.Size(75, 23);
			B_Save.TabIndex = 0;
			B_Save.Text = "Save";
			B_Save.UseVisualStyleBackColor = true;
			B_Save.Click += B_Save_Click;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
			tableLayoutPanel2.Controls.Add(pic_AI, 3, 1);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(label2, 0, 1);
			tableLayoutPanel2.Controls.Add(TB_UserIcon, 1, 0);
			tableLayoutPanel2.Controls.Add(TB_AIIcon, 1, 1);
			tableLayoutPanel2.Controls.Add(B_BrowseUser, 2, 0);
			tableLayoutPanel2.Controls.Add(B_BrowseAI, 2, 1);
			tableLayoutPanel2.Controls.Add(pic_User, 3, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel2.Size = new System.Drawing.Size(563, 188);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// pic_AI
			// 
			pic_AI.Dock = System.Windows.Forms.DockStyle.Fill;
			pic_AI.Location = new System.Drawing.Point(474, 97);
			pic_AI.Name = "pic_AI";
			pic_AI.Size = new System.Drawing.Size(86, 88);
			pic_AI.TabIndex = 7;
			pic_AI.TabStop = false;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 39);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 15);
			label1.TabIndex = 0;
			label1.Text = "User icon:";
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 133);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 1;
			label2.Text = "AI icon:";
			// 
			// TB_UserIcon
			// 
			TB_UserIcon.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_UserIcon.Location = new System.Drawing.Point(81, 35);
			TB_UserIcon.Name = "TB_UserIcon";
			TB_UserIcon.Size = new System.Drawing.Size(295, 23);
			TB_UserIcon.TabIndex = 2;
			TB_UserIcon.TextChanged += TB_UserIcon_TextChanged;
			// 
			// TB_AIIcon
			// 
			TB_AIIcon.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_AIIcon.Location = new System.Drawing.Point(81, 129);
			TB_AIIcon.Name = "TB_AIIcon";
			TB_AIIcon.Size = new System.Drawing.Size(295, 23);
			TB_AIIcon.TabIndex = 3;
			TB_AIIcon.TextChanged += TB_AIIcon_TextChanged;
			// 
			// B_BrowseUser
			// 
			B_BrowseUser.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_BrowseUser.Location = new System.Drawing.Point(382, 35);
			B_BrowseUser.Name = "B_BrowseUser";
			B_BrowseUser.Size = new System.Drawing.Size(86, 23);
			B_BrowseUser.TabIndex = 4;
			B_BrowseUser.Text = "Browse";
			B_BrowseUser.UseVisualStyleBackColor = true;
			B_BrowseUser.Click += B_BrowseUser_Click;
			// 
			// B_BrowseAI
			// 
			B_BrowseAI.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_BrowseAI.Location = new System.Drawing.Point(382, 129);
			B_BrowseAI.Name = "B_BrowseAI";
			B_BrowseAI.Size = new System.Drawing.Size(86, 23);
			B_BrowseAI.TabIndex = 5;
			B_BrowseAI.Text = "Browse";
			B_BrowseAI.UseVisualStyleBackColor = true;
			B_BrowseAI.Click += B_BrowseAI_Click;
			// 
			// pic_User
			// 
			pic_User.Dock = System.Windows.Forms.DockStyle.Fill;
			pic_User.Location = new System.Drawing.Point(474, 3);
			pic_User.Name = "pic_User";
			pic_User.Size = new System.Drawing.Size(86, 88);
			pic_User.TabIndex = 6;
			pic_User.TabStop = false;
			// 
			// EditDisplay
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(569, 229);
			Controls.Add(tableLayoutPanel1);
			Name = "EditDisplay";
			Text = "Edit AI display";
			Load += EditDisplay_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pic_AI).EndInit();
			((System.ComponentModel.ISupportInitialize)pic_User).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button B_Save;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TB_UserIcon;
		private System.Windows.Forms.TextBox TB_AIIcon;
		private System.Windows.Forms.Button B_BrowseUser;
		private System.Windows.Forms.Button B_BrowseAI;
		private System.Windows.Forms.PictureBox pic_User;
		private System.Windows.Forms.PictureBox pic_AI;
	}
}