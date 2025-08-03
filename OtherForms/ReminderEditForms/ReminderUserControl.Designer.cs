namespace SSC.OtherForms.ReminderEditForms
{
	partial class ReminderUserControl
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
			dateTimeEntity = new System.Windows.Forms.DateTimePicker();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			panel1 = new System.Windows.Forms.Panel();
			B_Remove = new System.Windows.Forms.Button();
			chk_Ack = new System.Windows.Forms.CheckBox();
			rb_Content = new System.Windows.Forms.RichTextBox();
			tableLayoutPanel1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// dateTimeEntity
			// 
			dateTimeEntity.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			dateTimeEntity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			dateTimeEntity.Location = new System.Drawing.Point(107, 3);
			dateTimeEntity.Name = "dateTimeEntity";
			dateTimeEntity.Size = new System.Drawing.Size(200, 23);
			dateTimeEntity.TabIndex = 0;
			dateTimeEntity.ValueChanged += dateTimeEntity_ValueChanged;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(panel1, 0, 0);
			tableLayoutPanel1.Controls.Add(rb_Content, 0, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			tableLayoutPanel1.Size = new System.Drawing.Size(416, 136);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// panel1
			// 
			panel1.Controls.Add(B_Remove);
			panel1.Controls.Add(dateTimeEntity);
			panel1.Controls.Add(chk_Ack);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(410, 30);
			panel1.TabIndex = 1;
			// 
			// B_Remove
			// 
			B_Remove.Location = new System.Drawing.Point(332, 3);
			B_Remove.Name = "B_Remove";
			B_Remove.Size = new System.Drawing.Size(75, 23);
			B_Remove.TabIndex = 1;
			B_Remove.Text = "Remove";
			B_Remove.UseVisualStyleBackColor = true;
			B_Remove.Click += B_Remove_Click;
			// 
			// chk_Ack
			// 
			chk_Ack.AutoSize = true;
			chk_Ack.Location = new System.Drawing.Point(3, 3);
			chk_Ack.Name = "chk_Ack";
			chk_Ack.Size = new System.Drawing.Size(98, 19);
			chk_Ack.TabIndex = 0;
			chk_Ack.Text = "Acknowledge";
			chk_Ack.UseVisualStyleBackColor = true;
			chk_Ack.CheckedChanged += chk_Ack_CheckedChanged;
			// 
			// rb_Content
			// 
			rb_Content.Dock = System.Windows.Forms.DockStyle.Fill;
			rb_Content.Location = new System.Drawing.Point(3, 39);
			rb_Content.Name = "rb_Content";
			rb_Content.Size = new System.Drawing.Size(410, 98);
			rb_Content.TabIndex = 2;
			rb_Content.Text = "";
			rb_Content.TextChanged += rb_Content_TextChanged;
			// 
			// ReminderUserControl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "ReminderUserControl";
			Size = new System.Drawing.Size(416, 136);
			tableLayoutPanel1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimeEntity;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chk_Ack;
		private System.Windows.Forms.RichTextBox rb_Content;
		private System.Windows.Forms.Button B_Remove;
	}
}
