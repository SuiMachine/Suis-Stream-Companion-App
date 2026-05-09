namespace SSC.Forms.VideoRewardsDBEditor
{
	partial class VideoDBEditor
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
			treeView1 = new System.Windows.Forms.TreeView();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			B_Sort = new System.Windows.Forms.Button();
			B_Remove = new System.Windows.Forms.Button();
			B_Add = new System.Windows.Forms.Button();
			B_OK = new System.Windows.Forms.Button();
			B_Cancel = new System.Windows.Forms.Button();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			B_Refresh = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			CB_SceneSelected = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			CB_MediaPlayer = new System.Windows.Forms.ComboBox();
			B_ConnectToObs = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(treeView1, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.70588F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.2941179F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
			tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// treeView1
			// 
			treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView1.Location = new System.Drawing.Point(3, 3);
			treeView1.Name = "treeView1";
			treeView1.Size = new System.Drawing.Size(794, 360);
			treeView1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 7;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
			tableLayoutPanel2.Controls.Add(B_Sort, 2, 0);
			tableLayoutPanel2.Controls.Add(B_Remove, 1, 0);
			tableLayoutPanel2.Controls.Add(B_Add, 0, 0);
			tableLayoutPanel2.Controls.Add(B_OK, 5, 0);
			tableLayoutPanel2.Controls.Add(B_Cancel, 6, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 411);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(794, 36);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// B_Sort
			// 
			B_Sort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			B_Sort.Location = new System.Drawing.Point(167, 6);
			B_Sort.Name = "B_Sort";
			B_Sort.Size = new System.Drawing.Size(75, 23);
			B_Sort.TabIndex = 2;
			B_Sort.Text = "Sort";
			B_Sort.UseVisualStyleBackColor = true;
			// 
			// B_Remove
			// 
			B_Remove.Anchor = System.Windows.Forms.AnchorStyles.Left;
			B_Remove.Location = new System.Drawing.Point(85, 6);
			B_Remove.Name = "B_Remove";
			B_Remove.Size = new System.Drawing.Size(75, 23);
			B_Remove.TabIndex = 1;
			B_Remove.Text = "Remove";
			B_Remove.UseVisualStyleBackColor = true;
			// 
			// B_Add
			// 
			B_Add.Anchor = System.Windows.Forms.AnchorStyles.Left;
			B_Add.Location = new System.Drawing.Point(3, 6);
			B_Add.Name = "B_Add";
			B_Add.Size = new System.Drawing.Size(75, 23);
			B_Add.TabIndex = 0;
			B_Add.Text = "Add";
			B_Add.UseVisualStyleBackColor = true;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(633, 6);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(75, 23);
			B_OK.TabIndex = 3;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			B_Cancel.Location = new System.Drawing.Point(716, 6);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(75, 23);
			B_Cancel.TabIndex = 4;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 6;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
			tableLayoutPanel3.Controls.Add(B_Refresh, 5, 0);
			tableLayoutPanel3.Controls.Add(label1, 0, 0);
			tableLayoutPanel3.Controls.Add(CB_SceneSelected, 1, 0);
			tableLayoutPanel3.Controls.Add(label2, 2, 0);
			tableLayoutPanel3.Controls.Add(CB_MediaPlayer, 3, 0);
			tableLayoutPanel3.Controls.Add(B_ConnectToObs, 4, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 369);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Size = new System.Drawing.Size(794, 36);
			tableLayoutPanel3.TabIndex = 2;
			// 
			// B_Refresh
			// 
			B_Refresh.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Refresh.Location = new System.Drawing.Point(714, 6);
			B_Refresh.Name = "B_Refresh";
			B_Refresh.Size = new System.Drawing.Size(75, 23);
			B_Refresh.TabIndex = 5;
			B_Refresh.Text = "Refresh";
			B_Refresh.UseVisualStyleBackColor = true;
			B_Refresh.Click += B_Refresh_Click;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 10);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(38, 15);
			label1.TabIndex = 0;
			label1.Text = "Scene";
			// 
			// CB_SceneSelected
			// 
			CB_SceneSelected.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			CB_SceneSelected.FormattingEnabled = true;
			CB_SceneSelected.Location = new System.Drawing.Point(47, 6);
			CB_SceneSelected.Name = "CB_SceneSelected";
			CB_SceneSelected.Size = new System.Drawing.Size(230, 23);
			CB_SceneSelected.TabIndex = 1;
			CB_SceneSelected.SelectedIndexChanged += CB_SceneSelected_SelectedIndexChanged;
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(283, 10);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(75, 15);
			label2.TabIndex = 2;
			label2.Text = "Media player";
			// 
			// CB_MediaPlayer
			// 
			CB_MediaPlayer.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			CB_MediaPlayer.FormattingEnabled = true;
			CB_MediaPlayer.Location = new System.Drawing.Point(369, 6);
			CB_MediaPlayer.Name = "CB_MediaPlayer";
			CB_MediaPlayer.Size = new System.Drawing.Size(230, 23);
			CB_MediaPlayer.TabIndex = 3;
			CB_MediaPlayer.SelectedIndexChanged += CB_MediaPlayer_SelectedIndexChanged;
			// 
			// B_ConnectToObs
			// 
			B_ConnectToObs.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_ConnectToObs.Location = new System.Drawing.Point(605, 6);
			B_ConnectToObs.Name = "B_ConnectToObs";
			B_ConnectToObs.Size = new System.Drawing.Size(102, 23);
			B_ConnectToObs.TabIndex = 4;
			B_ConnectToObs.Text = "Connect to OBS";
			B_ConnectToObs.UseVisualStyleBackColor = true;
			B_ConnectToObs.Click += B_ConnectToObs_Click;
			// 
			// VideoDBEditor
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(tableLayoutPanel1);
			Name = "VideoDBEditor";
			Text = "VideoDBEditor";
			FormClosed += VideoDBEditor_FormClosed;
			Load += VideoDBEditor_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button B_Remove;
		private System.Windows.Forms.Button B_Add;
		private System.Windows.Forms.Button B_Sort;
		private System.Windows.Forms.Button B_OK;
		private System.Windows.Forms.Button B_Cancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox CB_SceneSelected;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox CB_MediaPlayer;
		private System.Windows.Forms.Button B_ConnectToObs;
		private System.Windows.Forms.Button B_Refresh;
	}
}