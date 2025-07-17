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
			table_Layout = new System.Windows.Forms.TableLayoutPanel();
			picBox_AI = new System.Windows.Forms.PictureBox();
			picBox_User = new System.Windows.Forms.PictureBox();
			table_Layout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)picBox_AI).BeginInit();
			((System.ComponentModel.ISupportInitialize)picBox_User).BeginInit();
			SuspendLayout();
			// 
			// table_Layout
			// 
			table_Layout.AutoSize = true;
			table_Layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			table_Layout.ColumnCount = 3;
			table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			table_Layout.Controls.Add(picBox_AI, 0, 0);
			table_Layout.Controls.Add(picBox_User, 2, 0);
			table_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
			table_Layout.Location = new System.Drawing.Point(0, 0);
			table_Layout.Name = "table_Layout";
			table_Layout.RowCount = 1;
			table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			table_Layout.Size = new System.Drawing.Size(536, 72);
			table_Layout.TabIndex = 0;
			// 
			// picBox_AI
			// 
			picBox_AI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			picBox_AI.Dock = System.Windows.Forms.DockStyle.Fill;
			picBox_AI.Image = Properties.Resources.sia_gen;
			picBox_AI.InitialImage = null;
			picBox_AI.Location = new System.Drawing.Point(4, 4);
			picBox_AI.Name = "picBox_AI";
			picBox_AI.Size = new System.Drawing.Size(64, 64);
			picBox_AI.TabIndex = 0;
			picBox_AI.TabStop = false;
			// 
			// picBox_User
			// 
			picBox_User.Dock = System.Windows.Forms.DockStyle.Fill;
			picBox_User.Location = new System.Drawing.Point(468, 4);
			picBox_User.Name = "picBox_User";
			picBox_User.Size = new System.Drawing.Size(64, 64);
			picBox_User.TabIndex = 1;
			picBox_User.TabStop = false;
			// 
			// CasualChat_History
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(table_Layout);
			MinimumSize = new System.Drawing.Size(536, 72);
			Name = "CasualChat_History";
			Size = new System.Drawing.Size(536, 72);
			table_Layout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)picBox_AI).EndInit();
			((System.ComponentModel.ISupportInitialize)picBox_User).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel table_Layout;
		private System.Windows.Forms.PictureBox picBox_AI;
		private System.Windows.Forms.PictureBox picBox_User;
	}
}
