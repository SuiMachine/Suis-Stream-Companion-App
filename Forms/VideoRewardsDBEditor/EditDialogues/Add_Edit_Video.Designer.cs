namespace SSC.Forms.VideoRewardsDBEditor
{
	partial class Add_Edit_Video
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
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			B_OK = new System.Windows.Forms.Button();
			B_Cancel = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			numCooldown = new System.Windows.Forms.NumericUpDown();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			label1 = new System.Windows.Forms.Label();
			TB_Name = new System.Windows.Forms.TextBox();
			tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			label2 = new System.Windows.Forms.Label();
			ListBox_Files = new System.Windows.Forms.ListBox();
			contextMenu_Files = new System.Windows.Forms.ContextMenuStrip(components);
			addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			label3 = new System.Windows.Forms.Label();
			RB_Tags = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			label4 = new System.Windows.Forms.Label();
			RB_Description = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numCooldown).BeginInit();
			tableLayoutPanel3.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			contextMenu_Files.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			tableLayoutPanel7.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 5;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.Controls.Add(B_OK, 3, 0);
			tableLayoutPanel2.Controls.Add(B_Cancel, 4, 0);
			tableLayoutPanel2.Controls.Add(label5, 0, 0);
			tableLayoutPanel2.Controls.Add(numCooldown, 1, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 416);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(794, 31);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(637, 4);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(74, 23);
			B_OK.TabIndex = 0;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Cancel.Location = new System.Drawing.Point(717, 4);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(74, 23);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// label5
			// 
			label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 8);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(65, 15);
			label5.TabIndex = 2;
			label5.Text = "Cooldown:";
			// 
			// numCooldown
			// 
			numCooldown.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			numCooldown.Location = new System.Drawing.Point(100, 4);
			numCooldown.Name = "numCooldown";
			numCooldown.Size = new System.Drawing.Size(82, 23);
			numCooldown.TabIndex = 3;
			numCooldown.ValueChanged += numCooldown_ValueChanged;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 2);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel6, 0, 2);
			tableLayoutPanel3.Controls.Add(tableLayoutPanel7, 0, 1);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 4;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.Size = new System.Drawing.Size(794, 407);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.48730946F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.51269F));
			tableLayoutPanel4.Controls.Add(label1, 0, 0);
			tableLayoutPanel4.Controls.Add(TB_Name, 1, 0);
			tableLayoutPanel4.Location = new System.Drawing.Point(3, 4);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel4.Size = new System.Drawing.Size(788, 36);
			tableLayoutPanel4.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// TB_Name
			// 
			TB_Name.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_Name.Location = new System.Drawing.Point(62, 6);
			TB_Name.Name = "TB_Name";
			TB_Name.Size = new System.Drawing.Size(723, 23);
			TB_Name.TabIndex = 1;
			TB_Name.TextChanged += TB_Name_TextChanged;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel5.Controls.Add(label2, 0, 0);
			tableLayoutPanel5.Controls.Add(ListBox_Files, 0, 1);
			tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel5.Location = new System.Drawing.Point(3, 124);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 2;
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new System.Drawing.Size(788, 137);
			tableLayoutPanel5.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(33, 15);
			label2.TabIndex = 0;
			label2.Text = "Files:";
			// 
			// ListBox_Files
			// 
			ListBox_Files.AllowDrop = true;
			ListBox_Files.ContextMenuStrip = contextMenu_Files;
			ListBox_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			ListBox_Files.FormattingEnabled = true;
			ListBox_Files.ItemHeight = 15;
			ListBox_Files.Location = new System.Drawing.Point(3, 24);
			ListBox_Files.Name = "ListBox_Files";
			ListBox_Files.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			ListBox_Files.Size = new System.Drawing.Size(782, 110);
			ListBox_Files.TabIndex = 1;
			ListBox_Files.DragDrop += ListBox_Files_DragDrop;
			ListBox_Files.DragEnter += ListBox_Files_DragEnter;
			// 
			// contextMenu_Files
			// 
			contextMenu_Files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addToolStripMenuItem, removeToolStripMenuItem });
			contextMenu_Files.Name = "contextMenuStrip1";
			contextMenu_Files.Size = new System.Drawing.Size(118, 48);
			// 
			// addToolStripMenuItem
			// 
			addToolStripMenuItem.Name = "addToolStripMenuItem";
			addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			addToolStripMenuItem.Text = "Add";
			addToolStripMenuItem.Click += AddToolStripMenuItem_Click;
			// 
			// removeToolStripMenuItem
			// 
			removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			removeToolStripMenuItem.Text = "Remove";
			removeToolStripMenuItem.Click += RemoveToolStripMenuItem_Click;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.ColumnCount = 1;
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.Controls.Add(label3, 0, 0);
			tableLayoutPanel6.Controls.Add(RB_Tags, 0, 1);
			tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel6.Location = new System.Drawing.Point(3, 267);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 2;
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.Size = new System.Drawing.Size(788, 137);
			tableLayoutPanel6.TabIndex = 2;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 2);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(84, 15);
			label3.TabIndex = 0;
			label3.Text = "Tags / phrases:";
			// 
			// RB_Tags
			// 
			RB_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_Tags.Location = new System.Drawing.Point(3, 23);
			RB_Tags.Name = "RB_Tags";
			RB_Tags.Size = new System.Drawing.Size(782, 111);
			RB_Tags.TabIndex = 1;
			RB_Tags.Text = "";
			RB_Tags.TextChanged += RB_Tags_TextChanged;
			// 
			// tableLayoutPanel7
			// 
			tableLayoutPanel7.ColumnCount = 1;
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel7.Controls.Add(label4, 0, 0);
			tableLayoutPanel7.Controls.Add(RB_Description, 0, 1);
			tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel7.Location = new System.Drawing.Point(3, 47);
			tableLayoutPanel7.Name = "tableLayoutPanel7";
			tableLayoutPanel7.RowCount = 2;
			tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel7.Size = new System.Drawing.Size(788, 71);
			tableLayoutPanel7.TabIndex = 3;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(70, 15);
			label4.TabIndex = 0;
			label4.Text = "Description:";
			// 
			// RB_Description
			// 
			RB_Description.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_Description.Location = new System.Drawing.Point(3, 23);
			RB_Description.Name = "RB_Description";
			RB_Description.Size = new System.Drawing.Size(782, 45);
			RB_Description.TabIndex = 1;
			RB_Description.Text = "";
			RB_Description.TextChanged += RB_Description_TextChanged;
			// 
			// Add_Edit_Video
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(tableLayoutPanel1);
			Name = "Add_Edit_Video";
			Text = "Add video";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numCooldown).EndInit();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel5.PerformLayout();
			contextMenu_Files.ResumeLayout(false);
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			tableLayoutPanel7.ResumeLayout(false);
			tableLayoutPanel7.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button B_OK;
		private System.Windows.Forms.Button B_Cancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TB_Name;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox ListBox_Files;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox RB_Tags;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox RB_Description;
		private System.Windows.Forms.ContextMenuStrip contextMenu_Files;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numCooldown;
	}
}