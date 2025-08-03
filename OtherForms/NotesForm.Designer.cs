namespace SSC.AI_Integration
{
	partial class NotesForm
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
			chkList_Notes = new System.Windows.Forms.CheckedListBox();
			ctxMenu = new System.Windows.Forms.ContextMenuStrip(components);
			addEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ctxMenu.SuspendLayout();
			SuspendLayout();
			// 
			// chkList_Notes
			// 
			chkList_Notes.ContextMenuStrip = ctxMenu;
			chkList_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
			chkList_Notes.FormattingEnabled = true;
			chkList_Notes.Location = new System.Drawing.Point(0, 0);
			chkList_Notes.Name = "chkList_Notes";
			chkList_Notes.Size = new System.Drawing.Size(800, 450);
			chkList_Notes.TabIndex = 0;
			chkList_Notes.ItemCheck += chkList_Notes_ItemCheck;
			// 
			// ctxMenu
			// 
			ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addEntityToolStripMenuItem, editEntityToolStripMenuItem, removeToolStripMenuItem, openToolStripMenuItem, saveAsToolStripMenuItem });
			ctxMenu.Name = "ctxMenu";
			ctxMenu.Size = new System.Drawing.Size(181, 136);
			// 
			// addEntityToolStripMenuItem
			// 
			addEntityToolStripMenuItem.Name = "addEntityToolStripMenuItem";
			addEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			addEntityToolStripMenuItem.Text = "Add entity";
			addEntityToolStripMenuItem.Click += addEntityToolStripMenuItem_Click;
			// 
			// removeToolStripMenuItem
			// 
			removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			removeToolStripMenuItem.Text = "Remove entity";
			removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			openToolStripMenuItem.Text = "Open notes";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			saveAsToolStripMenuItem.Text = "Save as";
			saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
			// 
			// editEntityToolStripMenuItem
			// 
			editEntityToolStripMenuItem.Name = "editEntityToolStripMenuItem";
			editEntityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			editEntityToolStripMenuItem.Text = "Edit entity";
			editEntityToolStripMenuItem.Click += editEntityToolStripMenuItem_Click;
			// 
			// NotesForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(chkList_Notes);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "NotesForm";
			Text = "Notes";
			FormClosing += NotesForm_FormClosing;
			FormClosed += NotesForm_FormClosed;
			Load += NotesForm_Load;
			ctxMenu.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.CheckedListBox chkList_Notes;
		private System.Windows.Forms.ContextMenuStrip ctxMenu;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addEntityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editEntityToolStripMenuItem;
	}
}