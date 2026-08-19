using System;
using System.ComponentModel;
using System.Linq;

namespace SSC.SoundDatabaseEditor.EditDialogues
{
    partial class SoundPlaybackSettingsDialog
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
			tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			B_OK = new System.Windows.Forms.Button();
			B_Cancel = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			CB_OutputDevices = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel5.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 0, 1);
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
			tableLayoutPanel1.Size = new System.Drawing.Size(560, 106);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 2;
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel5.Controls.Add(B_OK, 0, 0);
			tableLayoutPanel5.Controls.Add(B_Cancel, 1, 0);
			tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right;
			tableLayoutPanel5.Location = new System.Drawing.Point(330, 67);
			tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 1;
			tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel5.Size = new System.Drawing.Size(226, 36);
			tableLayoutPanel5.TabIndex = 1;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(12, 4);
			B_OK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(88, 27);
			B_OK.TabIndex = 0;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Cancel.Location = new System.Drawing.Point(125, 4);
			B_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(88, 27);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(CB_OutputDevices);
			panel1.Controls.Add(label1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(4, 3);
			panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(552, 58);
			panel1.TabIndex = 2;
			// 
			// CB_OutputDevices
			// 
			CB_OutputDevices.FormattingEnabled = true;
			CB_OutputDevices.Location = new System.Drawing.Point(100, 3);
			CB_OutputDevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			CB_OutputDevices.Name = "CB_OutputDevices";
			CB_OutputDevices.Size = new System.Drawing.Size(443, 23);
			CB_OutputDevices.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(4, 7);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(85, 15);
			label1.TabIndex = 0;
			label1.Text = "Output device:";
			// 
			// SoundPlaybackSettingsDialog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(560, 106);
			ControlBox = false;
			Controls.Add(tableLayoutPanel1);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SoundPlaybackSettingsDialog";
			Text = "Sound Playback Settings";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel5.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button B_OK;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CB_OutputDevices;
	}
}