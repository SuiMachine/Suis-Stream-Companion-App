namespace SSC.OtherForms.Notes
{
	partial class AddEditNotes
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
			label1 = new System.Windows.Forms.Label();
			rbText_Note = new System.Windows.Forms.RichTextBox();
			CB_Completed = new System.Windows.Forms.CheckBox();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			B_Cancel = new System.Windows.Forms.Button();
			B_OK = new System.Windows.Forms.Button();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(label1, 0, 0);
			tableLayoutPanel1.Controls.Add(rbText_Note, 0, 1);
			tableLayoutPanel1.Controls.Add(CB_Completed, 0, 2);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			tableLayoutPanel1.Size = new System.Drawing.Size(355, 278);
			tableLayoutPanel1.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(36, 15);
			label1.TabIndex = 1;
			label1.Text = "Note:";
			// 
			// rbText_Note
			// 
			rbText_Note.Dock = System.Windows.Forms.DockStyle.Fill;
			rbText_Note.Location = new System.Drawing.Point(3, 23);
			rbText_Note.Name = "rbText_Note";
			rbText_Note.Size = new System.Drawing.Size(349, 223);
			rbText_Note.TabIndex = 2;
			rbText_Note.Text = "";
			// 
			// CB_Completed
			// 
			CB_Completed.AutoSize = true;
			CB_Completed.Location = new System.Drawing.Point(3, 252);
			CB_Completed.Name = "CB_Completed";
			CB_Completed.Size = new System.Drawing.Size(85, 19);
			CB_Completed.TabIndex = 3;
			CB_Completed.Text = "Completed";
			CB_Completed.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 1;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 0);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 2;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			tableLayoutPanel2.Size = new System.Drawing.Size(361, 321);
			tableLayoutPanel2.TabIndex = 2;
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(B_Cancel, 1, 0);
			tableLayoutPanel3.Controls.Add(B_OK, 0, 0);
			tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
			tableLayoutPanel3.Location = new System.Drawing.Point(191, 287);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			tableLayoutPanel3.Size = new System.Drawing.Size(167, 31);
			tableLayoutPanel3.TabIndex = 2;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Cancel.Location = new System.Drawing.Point(87, 4);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(75, 23);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(4, 4);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(75, 23);
			B_OK.TabIndex = 0;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// AddEditNotes
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(361, 321);
			Controls.Add(tableLayoutPanel2);
			Name = "AddEditNotes";
			Text = "AddEditNotes";
			Load += AddEditNotes_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel3.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button B_OK;
		private System.Windows.Forms.Button B_Cancel;
		private System.Windows.Forms.RichTextBox rbText_Note;
		private System.Windows.Forms.CheckBox CB_Completed;
	}
}