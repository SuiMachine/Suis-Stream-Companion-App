namespace SSC.Forms.VSS
{
	partial class VSS_Editor
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
			TB_MasterKeybind = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			treeView_VSS_Options = new System.Windows.Forms.TreeView();
			contextMenuTreeViewVSS = new System.Windows.Forms.ContextMenuStrip(components);
			addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			removeElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			contextMenuTreeViewVSS.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 1;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
			tableLayoutPanel1.Controls.Add(treeView_VSS_Options, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
			tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 4;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
			tableLayoutPanel2.Controls.Add(B_OK, 2, 0);
			tableLayoutPanel2.Controls.Add(B_Cancel, 3, 0);
			tableLayoutPanel2.Controls.Add(TB_MasterKeybind, 1, 0);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel2.Location = new System.Drawing.Point(3, 418);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 1;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			tableLayoutPanel2.Size = new System.Drawing.Size(794, 29);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// B_OK
			// 
			B_OK.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_OK.Location = new System.Drawing.Point(627, 3);
			B_OK.Name = "B_OK";
			B_OK.Size = new System.Drawing.Size(75, 23);
			B_OK.TabIndex = 0;
			B_OK.Text = "OK";
			B_OK.UseVisualStyleBackColor = true;
			B_OK.Click += B_OK_Click;
			// 
			// B_Cancel
			// 
			B_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
			B_Cancel.Location = new System.Drawing.Point(713, 3);
			B_Cancel.Name = "B_Cancel";
			B_Cancel.Size = new System.Drawing.Size(75, 23);
			B_Cancel.TabIndex = 1;
			B_Cancel.Text = "Cancel";
			B_Cancel.UseVisualStyleBackColor = true;
			B_Cancel.Click += B_Cancel_Click;
			// 
			// TB_MasterKeybind
			// 
			TB_MasterKeybind.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			TB_MasterKeybind.Location = new System.Drawing.Point(78, 3);
			TB_MasterKeybind.Name = "TB_MasterKeybind";
			TB_MasterKeybind.Size = new System.Drawing.Size(541, 23);
			TB_MasterKeybind.TabIndex = 2;
			TB_MasterKeybind.KeyDown += TB_MasterKey_KeyDown;
			// 
			// label1
			// 
			label1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 7);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(69, 15);
			label1.TabIndex = 3;
			label1.Text = "Master key:";
			// 
			// treeView_VSS_Options
			// 
			treeView_VSS_Options.ContextMenuStrip = contextMenuTreeViewVSS;
			treeView_VSS_Options.Dock = System.Windows.Forms.DockStyle.Fill;
			treeView_VSS_Options.Location = new System.Drawing.Point(3, 3);
			treeView_VSS_Options.Name = "treeView_VSS_Options";
			treeView_VSS_Options.Size = new System.Drawing.Size(794, 409);
			treeView_VSS_Options.TabIndex = 1;
			treeView_VSS_Options.AfterCollapse += treeView_VSS_Options_AfterCollapse;
			treeView_VSS_Options.AfterExpand += treeView_VSS_Options_AfterExpand;
			// 
			// contextMenuTreeViewVSS
			// 
			contextMenuTreeViewVSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { addElementToolStripMenuItem, removeElementToolStripMenuItem, cancelToolStripMenuItem });
			contextMenuTreeViewVSS.Name = "contextMenuTreeViewVSS";
			contextMenuTreeViewVSS.Size = new System.Drawing.Size(164, 70);
			contextMenuTreeViewVSS.Opening += contextMenuTreeViewVSS_Opening;
			// 
			// addElementToolStripMenuItem
			// 
			addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
			addElementToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			addElementToolStripMenuItem.Text = "Add element";
			addElementToolStripMenuItem.Click += addElementToolStripMenuItem_Click;
			// 
			// removeElementToolStripMenuItem
			// 
			removeElementToolStripMenuItem.Name = "removeElementToolStripMenuItem";
			removeElementToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			removeElementToolStripMenuItem.Text = "Remove element";
			removeElementToolStripMenuItem.Click += removeElementToolStripMenuItem_Click;
			// 
			// cancelToolStripMenuItem
			// 
			cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
			cancelToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			cancelToolStripMenuItem.Text = "Cancel";
			// 
			// VSS_Editor
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(tableLayoutPanel1);
			Name = "VSS_Editor";
			Text = "VSS editor";
			Load += VSS_Editor_Load;
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			contextMenuTreeViewVSS.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button B_OK;
		private System.Windows.Forms.Button B_Cancel;
		private System.Windows.Forms.TreeView treeView_VSS_Options;
		private System.Windows.Forms.TextBox TB_MasterKeybind;
		private System.Windows.Forms.ContextMenuStrip contextMenuTreeViewVSS;
		private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeElementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
		private System.Windows.Forms.Label label1;
	}
}