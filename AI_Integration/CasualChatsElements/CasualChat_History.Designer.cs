namespace SSC.AI_Integration.CasualChatsElements
{
	partial class CasualChat_History
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasualChat_History));
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			picBox_AI = new System.Windows.Forms.PictureBox();
			picBox_User = new System.Windows.Forms.PictureBox();
			L_Text = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picBox_AI).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBox_User).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel1.Controls.Add(picBox_AI, 0, 0);
			tableLayoutPanel1.Controls.Add(picBox_User, 2, 0);
			tableLayoutPanel1.Controls.Add(L_Text, 1, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Size = new System.Drawing.Size(536, 112);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// picBox_AI
			// 
			picBox_AI.Dock = System.Windows.Forms.DockStyle.Fill;
			picBox_AI.InitialImage = (System.Drawing.Image)resources.GetObject("picBox_AI.InitialImage");
			picBox_AI.Location = new System.Drawing.Point(3, 3);
			picBox_AI.Name = "picBox_AI";
			picBox_AI.Size = new System.Drawing.Size(57, 106);
			picBox_AI.TabIndex = 0;
			picBox_AI.TabStop = false;
			// 
			// picBox_User
			// 
			picBox_User.Dock = System.Windows.Forms.DockStyle.Fill;
			picBox_User.Location = new System.Drawing.Point(481, 3);
			picBox_User.Name = "picBox_User";
			picBox_User.Size = new System.Drawing.Size(52, 106);
			picBox_User.TabIndex = 1;
			picBox_User.TabStop = false;
			// 
			// L_Text
			// 
			L_Text.AutoSize = true;
			L_Text.Location = new System.Drawing.Point(66, 0);
			L_Text.Name = "L_Text";
			L_Text.Size = new System.Drawing.Size(38, 15);
			L_Text.TabIndex = 2;
			L_Text.Text = "label1";
			// 
			// CasualChat_History
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "CasualChat_History";
			Size = new System.Drawing.Size(536, 112);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)picBox_AI).EndInit();
			((System.ComponentModel.ISupportInitialize)picBox_User).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.PictureBox picBox_AI;
		private System.Windows.Forms.PictureBox picBox_User;
		private System.Windows.Forms.Label L_Text;
	}
}
