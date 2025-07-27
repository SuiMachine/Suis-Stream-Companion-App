namespace SSC.AI_Integration
{
	partial class AI_Notes
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
			chkList_Notes = new System.Windows.Forms.CheckedListBox();
			SuspendLayout();
			// 
			// chkList_Notes
			// 
			chkList_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
			chkList_Notes.FormattingEnabled = true;
			chkList_Notes.Location = new System.Drawing.Point(0, 0);
			chkList_Notes.Name = "chkList_Notes";
			chkList_Notes.Size = new System.Drawing.Size(800, 450);
			chkList_Notes.TabIndex = 0;
			// 
			// AI_Notes
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(chkList_Notes);
			Name = "AI_Notes";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.CheckedListBox chkList_Notes;
	}
}