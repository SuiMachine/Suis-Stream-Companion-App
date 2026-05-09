using System;
using System.ComponentModel;
using System.Linq;

namespace SSC.SoundDatabaseEditor.EditDialogues
{
    partial class AddEditNewEntryDialog
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
			components = new Container();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			label8 = new System.Windows.Forms.Label();
			RB_Tags = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			label3 = new System.Windows.Forms.Label();
			TB_RewardID = new System.Windows.Forms.TextBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			label1 = new System.Windows.Forms.Label();
			TB_RewardName = new System.Windows.Forms.TextBox();
			tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			B_RemoveReward = new System.Windows.Forms.Button();
			B_CreateReward = new System.Windows.Forms.Button();
			B_Cancel = new System.Windows.Forms.Button();
			B_OK = new System.Windows.Forms.Button();
			tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			label4 = new System.Windows.Forms.Label();
			RB_Description = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			label2 = new System.Windows.Forms.Label();
			ListB_Files = new System.Windows.Forms.ListBox();
			contextMenu_File = new System.Windows.Forms.ContextMenuStrip(components);
			addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			Num_Cooldown = new System.Windows.Forms.NumericUpDown();
			Num_Points = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			Num_Volume = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel8.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			tableLayoutPanel6.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			contextMenu_File.SuspendLayout();
			tableLayoutPanel7.SuspendLayout();
			((ISupportInitialize)Num_Cooldown).BeginInit();
			((ISupportInitialize)Num_Points).BeginInit();
			((ISupportInitialize)Num_Volume).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel8, 0, 3);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 5);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 6);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 0, 1);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel7, 0, 4);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 7;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			tableLayoutPanel1.Size = new System.Drawing.Size(565, 704);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel8
			// 
			tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel8.ColumnCount = 1;
			tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel8.Controls.Add(label8, 0, 0);
			tableLayoutPanel8.Controls.Add(RB_Tags, 0, 1);
			tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel8.Location = new System.Drawing.Point(4, 364);
			tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel8.Name = "tableLayoutPanel8";
			tableLayoutPanel8.RowCount = 2;
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel8.Size = new System.Drawing.Size(557, 215);
			tableLayoutPanel8.TabIndex = 7;
			// 
			// label8
			// 
			label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(5, 5);
			label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(295, 15);
			label8.TabIndex = 0;
			label8.Text = "Tags / phrase (only alpha-numeric characters allowed):";
			// 
			// RB_Tags
			// 
			RB_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_Tags.Location = new System.Drawing.Point(5, 28);
			RB_Tags.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			RB_Tags.Name = "RB_Tags";
			RB_Tags.Size = new System.Drawing.Size(548, 183);
			RB_Tags.TabIndex = 1;
			RB_Tags.Text = "";
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel4.Controls.Add(label3, 0, 0);
			tableLayoutPanel4.Controls.Add(TB_RewardID, 1, 0);
			tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel4.Location = new System.Drawing.Point(4, 622);
			tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 2;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel4.Size = new System.Drawing.Size(557, 36);
			tableLayoutPanel4.TabIndex = 5;
			// 
			// label3
			// 
			label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(5, 8);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(63, 15);
			label3.TabIndex = 0;
			label3.Text = "Reward ID:";
			// 
			// TB_RewardID
			// 
			TB_RewardID.Dock = System.Windows.Forms.DockStyle.Fill;
			TB_RewardID.Enabled = false;
			TB_RewardID.Location = new System.Drawing.Point(92, 4);
			TB_RewardID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TB_RewardID.Name = "TB_RewardID";
			TB_RewardID.Size = new System.Drawing.Size(460, 23);
			TB_RewardID.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(TB_RewardName, 1, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(4, 3);
			tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel2.Size = new System.Drawing.Size(557, 32);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 8);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 15);
			label1.TabIndex = 0;
			label1.Text = "Name:";
			// 
			// TB_RewardName
			// 
			TB_RewardName.Dock = System.Windows.Forms.DockStyle.Fill;
			TB_RewardName.Location = new System.Drawing.Point(60, 4);
			TB_RewardName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			TB_RewardName.Name = "TB_RewardName";
			TB_RewardName.Size = new System.Drawing.Size(492, 23);
			TB_RewardName.TabIndex = 1;
			TB_RewardName.TextChanged += TB_Command_TextChanged;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 4;
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
			tableLayoutPanel5.Controls.Add(B_RemoveReward, 1, 0);
			tableLayoutPanel5.Controls.Add(B_CreateReward, 0, 0);
			tableLayoutPanel5.Controls.Add(B_Cancel, 3, 0);
			tableLayoutPanel5.Controls.Add(B_OK, 2, 0);
			tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel5.Location = new System.Drawing.Point(4, 664);
			tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 1;
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new System.Drawing.Size(557, 37);
			tableLayoutPanel5.TabIndex = 3;
			// 
			// B_RemoveReward
			// 
			B_RemoveReward.Dock = System.Windows.Forms.DockStyle.Left;
			B_RemoveReward.Location = new System.Drawing.Point(160, 3);
			B_RemoveReward.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_RemoveReward.Name = "B_RemoveReward";
			B_RemoveReward.Size = new System.Drawing.Size(120, 31);
			B_RemoveReward.TabIndex = 3;
			B_RemoveReward.Text = "Remove reward";
			B_RemoveReward.UseVisualStyleBackColor = true;
			B_RemoveReward.Click += B_RemoveReward_Click;
			// 
			// B_CreateReward
			// 
			B_CreateReward.Dock = System.Windows.Forms.DockStyle.Left;
			B_CreateReward.Location = new System.Drawing.Point(4, 3);
			B_CreateReward.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_CreateReward.Name = "B_CreateReward";
			B_CreateReward.Size = new System.Drawing.Size(146, 31);
			B_CreateReward.TabIndex = 2;
			B_CreateReward.Text = "Create / update reward";
			B_CreateReward.UseVisualStyleBackColor = true;
			B_CreateReward.Click += B_CreateReward_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Cancel.Location = new System.Drawing.Point(454, 5);
			B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(88, 27);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(337, 5);
			B_OK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(88, 27);
			B_OK.TabIndex = 0;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel6.ColumnCount = 1;
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel6.Controls.Add(label4, 0, 0);
			tableLayoutPanel6.Controls.Add(RB_Description, 0, 1);
			tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel6.Location = new System.Drawing.Point(4, 41);
			tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 2;
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel6.Size = new System.Drawing.Size(557, 96);
			tableLayoutPanel6.TabIndex = 4;
			// 
			// label4
			// 
			label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(5, 7);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(121, 15);
			label4.TabIndex = 1;
			label4.Text = "Description (Prompt):";
			// 
			// RB_Description
			// 
			RB_Description.DetectUrls = false;
			RB_Description.Dock = System.Windows.Forms.DockStyle.Fill;
			RB_Description.Location = new System.Drawing.Point(5, 32);
			RB_Description.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			RB_Description.Name = "RB_Description";
			RB_Description.Size = new System.Drawing.Size(547, 60);
			RB_Description.TabIndex = 2;
			RB_Description.Text = "";
			RB_Description.TextChanged += RB_Description_TextChanged;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			tableLayoutPanel3.Controls.Add(label2, 0, 0);
			tableLayoutPanel3.Controls.Add(ListB_Files, 0, 1);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(4, 143);
			tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(557, 215);
			tableLayoutPanel3.TabIndex = 1;
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(5, 5);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(33, 15);
			label2.TabIndex = 0;
			label2.Text = "Files:";
			// 
			// ListB_Files
			// 
			ListB_Files.AllowDrop = true;
			ListB_Files.ContextMenuStrip = contextMenu_File;
			ListB_Files.Dock = System.Windows.Forms.DockStyle.Fill;
			ListB_Files.FormattingEnabled = true;
			ListB_Files.ItemHeight = 15;
			ListB_Files.Location = new System.Drawing.Point(5, 28);
			ListB_Files.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			ListB_Files.Name = "ListB_Files";
			ListB_Files.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			ListB_Files.Size = new System.Drawing.Size(549, 183);
			ListB_Files.TabIndex = 1;
			ListB_Files.DragDrop += ListB_Files_DragDrop;
			ListB_Files.DragEnter += ListB_Files_DragEnter;
			// 
			// contextMenu_File
			// 
			contextMenu_File.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addFileToolStripMenuItem, removeFileToolStripMenuItem });
			contextMenu_File.Name = "contextMenu_File";
			contextMenu_File.Size = new System.Drawing.Size(150, 48);
			// 
			// addFileToolStripMenuItem
			// 
			addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
			addFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			addFileToolStripMenuItem.Text = "Add file(s)";
			addFileToolStripMenuItem.Click += AddFileToolStripMenuItem_Click;
			// 
			// removeFileToolStripMenuItem
			// 
			removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
			removeFileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			removeFileToolStripMenuItem.Text = "Remove file(s)";
			removeFileToolStripMenuItem.Click += RemoveFileToolStripMenuItem_Click;
			// 
			// tableLayoutPanel7
			// 
			tableLayoutPanel7.ColumnCount = 6;
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
			tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			tableLayoutPanel7.Controls.Add(Num_Cooldown, 5, 0);
			tableLayoutPanel7.Controls.Add(Num_Points, 3, 0);
			tableLayoutPanel7.Controls.Add(label6, 2, 0);
			tableLayoutPanel7.Controls.Add(label5, 0, 0);
			tableLayoutPanel7.Controls.Add(Num_Volume, 1, 0);
			tableLayoutPanel7.Controls.Add(label7, 4, 0);
			tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel7.Location = new System.Drawing.Point(4, 585);
			tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel7.Name = "tableLayoutPanel7";
			tableLayoutPanel7.RowCount = 1;
			tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel7.Size = new System.Drawing.Size(557, 31);
			tableLayoutPanel7.TabIndex = 6;
			// 
			// Num_Cooldown
			// 
			Num_Cooldown.Dock = System.Windows.Forms.DockStyle.Fill;
			Num_Cooldown.Location = new System.Drawing.Point(470, 3);
			Num_Cooldown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Num_Cooldown.Maximum = new decimal(new int[] { 604800, 0, 0, 0 });
			Num_Cooldown.Name = "Num_Cooldown";
			Num_Cooldown.Size = new System.Drawing.Size(83, 23);
			Num_Cooldown.TabIndex = 7;
			// 
			// Num_Points
			// 
			Num_Points.Dock = System.Windows.Forms.DockStyle.Fill;
			Num_Points.Location = new System.Drawing.Point(288, 3);
			Num_Points.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Num_Points.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
			Num_Points.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			Num_Points.Name = "Num_Points";
			Num_Points.Size = new System.Drawing.Size(82, 23);
			Num_Points.TabIndex = 5;
			Num_Points.Value = new decimal(new int[] { 500, 0, 0, 0 });
			// 
			// label6
			// 
			label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(157, 8);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(115, 15);
			label6.TabIndex = 4;
			label6.Text = "Channel points cost:";
			// 
			// label5
			// 
			label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(4, 8);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(50, 15);
			label5.TabIndex = 2;
			label5.Text = "Volume:";
			// 
			// Num_Volume
			// 
			Num_Volume.Dock = System.Windows.Forms.DockStyle.Fill;
			Num_Volume.Location = new System.Drawing.Point(67, 3);
			Num_Volume.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Num_Volume.Name = "Num_Volume";
			Num_Volume.Size = new System.Drawing.Size(82, 23);
			Num_Volume.TabIndex = 3;
			Num_Volume.Value = new decimal(new int[] { 100, 0, 0, 0 });
			// 
			// label7
			// 
			label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(378, 8);
			label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(65, 15);
			label7.TabIndex = 6;
			label7.Text = "Cooldown:";
			// 
			// AddEditNewEntryDialog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(565, 704);
			Controls.Add(tableLayoutPanel1);
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MinimizeBox = false;
			MinimumSize = new System.Drawing.Size(581, 482);
			Name = "AddEditNewEntryDialog";
			ShowIcon = false;
			Text = "Add new entry";
			Load += AddEditNewEntryDialog_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel8.ResumeLayout(false);
			tableLayoutPanel8.PerformLayout();
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel5.ResumeLayout(false);
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel6.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			contextMenu_File.ResumeLayout(false);
			tableLayoutPanel7.ResumeLayout(false);
			tableLayoutPanel7.PerformLayout();
			((ISupportInitialize)Num_Cooldown).EndInit();
			((ISupportInitialize)Num_Points).EndInit();
			((ISupportInitialize)Num_Volume).EndInit();
			ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_RewardName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ListB_Files;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.ContextMenuStrip contextMenu_File;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox RB_Description;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button B_CreateReward;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown Num_Volume;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.NumericUpDown Num_Points;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown Num_Cooldown;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox TB_RewardID;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button B_RemoveReward;
		private System.Windows.Forms.RichTextBox RB_Tags;
	}
}