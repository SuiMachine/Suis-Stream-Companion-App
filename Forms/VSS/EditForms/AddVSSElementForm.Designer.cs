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
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			listBoxSounds = new System.Windows.Forms.ListBox();
			tabPageVideo = new System.Windows.Forms.TabPage();
			tabPageContainer = new System.Windows.Forms.TabPage();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			B_Cancel = new System.Windows.Forms.Button();
			B_OK = new System.Windows.Forms.Button();
			tabControlVSSAddType.SuspendLayout();
			tabPageSound.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
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
			tabPageSound.Controls.Add(tableLayoutPanel3);
			tabPageSound.Location = new System.Drawing.Point(4, 24);
			tabPageSound.Name = "tabPageSound";
			tabPageSound.Padding = new System.Windows.Forms.Padding(3);
			tabPageSound.Size = new System.Drawing.Size(786, 379);
			tabPageSound.TabIndex = 0;
			tabPageSound.Text = "Sound";
			tabPageSound.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 1;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.Controls.Add(listBoxSounds, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 2;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			tableLayoutPanel3.Size = new System.Drawing.Size(780, 373);
			tableLayoutPanel3.TabIndex = 0;
			// 
			// listBoxSounds
			// 
			listBoxSounds.Dock = System.Windows.Forms.DockStyle.Fill;
			listBoxSounds.FormattingEnabled = true;
			listBoxSounds.ItemHeight = 15;
			listBoxSounds.Location = new System.Drawing.Point(3, 3);
			listBoxSounds.Name = "listBoxSounds";
			listBoxSounds.Size = new System.Drawing.Size(774, 335);
			listBoxSounds.TabIndex = 0;
			// 
			// tabPageVideo
			// 
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
			tabPageContainer.Location = new System.Drawing.Point(4, 24);
			tabPageContainer.Name = "tabPageContainer";
			tabPageContainer.Size = new System.Drawing.Size(786, 379);
			tabPageContainer.TabIndex = 2;
			tabPageContainer.Text = "Container";
			tabPageContainer.UseVisualStyleBackColor = true;
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
			tableLayoutPanel2.ColumnCount = 3;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel2.Controls.Add(B_Cancel, 2, 0);
			tableLayoutPanel2.Controls.Add(B_OK, 1, 0);
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
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ListBox listBoxSounds;
	}
}