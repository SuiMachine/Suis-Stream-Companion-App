namespace SSC.Forms.VSS.EditForms
{
	partial class AddVSSElementForm
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
			tabControlVSSAddType = new System.Windows.Forms.TabControl();
			tabPageSound = new System.Windows.Forms.TabPage();
			listBoxSounds = new System.Windows.Forms.ListBox();
			tabPageVideo = new System.Windows.Forms.TabPage();
			tabPageContainer = new System.Windows.Forms.TabPage();
			tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			label1 = new System.Windows.Forms.Label();
			TB_ContainerName = new System.Windows.Forms.TextBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			B_Cancel = new System.Windows.Forms.Button();
			B_OK = new System.Windows.Forms.Button();
			label2 = new System.Windows.Forms.Label();
			TB_Key = new System.Windows.Forms.TextBox();
			listBoxVideos = new System.Windows.Forms.ListBox();
			tabControlVSSAddType.SuspendLayout();
			tabPageSound.SuspendLayout();
			tabPageVideo.SuspendLayout();
			tabPageContainer.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			SuspendLayout();
			// 
			// tabControlVSSAddType
			// 
			tabControlVSSAddType.Controls.Add(tabPageSound);
			tabControlVSSAddType.Controls.Add(tabPageVideo);
			tabControlVSSAddType.Controls.Add(tabPageContainer);
			tabControlVSSAddType.Dock = System.Windows.Forms.DockStyle.Fill;
			tabControlVSSAddType.Location = new System.Drawing.Point(3, 3);
			tabControlVSSAddType.Name = "tabControlVSSAddType";
			tabControlVSSAddType.SelectedIndex = 0;
			tabControlVSSAddType.Size = new System.Drawing.Size(794, 407);
			tabControlVSSAddType.TabIndex = 0;
			// 
			// tabPageSound
			// 
			tabPageSound.Controls.Add(listBoxSounds);
			tabPageSound.Location = new System.Drawing.Point(4, 24);
			tabPageSound.Name = "tabPageSound";
			tabPageSound.Padding = new System.Windows.Forms.Padding(3);
			tabPageSound.Size = new System.Drawing.Size(786, 379);
			tabPageSound.TabIndex = 0;
			tabPageSound.Text = "Sound";
			tabPageSound.UseVisualStyleBackColor = true;
			// 
			// listBoxSounds
			// 
			listBoxSounds.Dock = System.Windows.Forms.DockStyle.Fill;
			listBoxSounds.FormattingEnabled = true;
			listBoxSounds.ItemHeight = 15;
			listBoxSounds.Location = new System.Drawing.Point(3, 3);
			listBoxSounds.Name = "listBoxSounds";
			listBoxSounds.Size = new System.Drawing.Size(780, 373);
			listBoxSounds.TabIndex = 0;
			// 
			// tabPageVideo
			// 
			tabPageVideo.Controls.Add(listBoxVideos);
			tabPageVideo.Location = new System.Drawing.Point(4, 24);
			tabPageVideo.Name = "tabPageVideo";
			tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
			tabPageVideo.Size = new System.Drawing.Size(786, 379);
			tabPageVideo.TabIndex = 1;
			tabPageVideo.Text = "Video (OBS)";
			tabPageVideo.UseVisualStyleBackColor = true;
			// 
			// tabPageContainer
			// 
			tabPageContainer.Controls.Add(tableLayoutPanel4);
			tabPageContainer.Location = new System.Drawing.Point(4, 24);
			tabPageContainer.Name = "tabPageContainer";
			tabPageContainer.Size = new System.Drawing.Size(786, 379);
			tabPageContainer.TabIndex = 2;
			tabPageContainer.Text = "Container";
			tabPageContainer.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.Controls.Add(label1, 0, 0);
			tableLayoutPanel4.Controls.Add(TB_ContainerName, 1, 0);
			tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 2;
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel4.Size = new System.Drawing.Size(786, 379);
			tableLayoutPanel4.TabIndex = 0;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(69, 15);
			label1.TabIndex = 0;
			label1.Text = "Tree name:";
			// 
			// TB_ContainerName
			// 
			TB_ContainerName.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_ContainerName.Location = new System.Drawing.Point(78, 3);
			TB_ContainerName.Name = "TB_ContainerName";
			TB_ContainerName.Size = new System.Drawing.Size(705, 23);
			TB_ContainerName.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tabControlVSSAddType, 0, 0);
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel2.Controls.Add(B_Cancel, 3, 0);
			tableLayoutPanel2.Controls.Add(B_OK, 2, 0);
			tableLayoutPanel2.Controls.Add(label2, 0, 0);
			tableLayoutPanel2.Controls.Add(TB_Key, 1, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 416);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(794, 31);
			tableLayoutPanel2.TabIndex = 1;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_Cancel.Location = new System.Drawing.Point(717, 4);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(74, 23);
			B_Cancel.TabIndex = 0;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			B_OK.Location = new System.Drawing.Point(637, 4);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(74, 23);
			B_OK.TabIndex = 1;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// label2
			// 
			label2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 8);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(33, 15);
			label2.TabIndex = 2;
			label2.Text = "Key:";
			// 
			// TB_Key
			// 
			TB_Key.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_Key.Location = new System.Drawing.Point(42, 4);
			TB_Key.Name = "TB_Key";
			TB_Key.Size = new System.Drawing.Size(589, 23);
			TB_Key.TabIndex = 3;
			// 
			// listBoxVideos
			// 
			listBoxVideos.Dock = System.Windows.Forms.DockStyle.Fill;
			listBoxVideos.FormattingEnabled = true;
			listBoxVideos.ItemHeight = 15;
			listBoxVideos.Location = new System.Drawing.Point(3, 3);
			listBoxVideos.Name = "listBoxVideos";
			listBoxVideos.Size = new System.Drawing.Size(780, 373);
			listBoxVideos.TabIndex = 0;
			// 
			// AddVSSElementForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(tableLayoutPanel1);
			Name = "AddVSSElementForm";
			Text = "Add VSS tree element";
			Load += AddVSSElementForm_Load;
			tabControlVSSAddType.ResumeLayout(false);
			tabPageSound.ResumeLayout(false);
			tabPageVideo.ResumeLayout(false);
			tabPageContainer.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			tableLayoutPanel4.PerformLayout();
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TabControl tabControlVSSAddType;
		private System.Windows.Forms.TabPage tabPageSound;
		private System.Windows.Forms.TabPage tabPageVideo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TabPage tabPageContainer;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button B_Cancel;
		private System.Windows.Forms.Button B_OK;
		private System.Windows.Forms.ListBox listBoxSounds;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TB_ContainerName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TB_Key;
		private System.Windows.Forms.ListBox listBoxVideos;
	}
}