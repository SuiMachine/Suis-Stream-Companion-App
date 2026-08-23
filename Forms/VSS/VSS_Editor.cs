using SSC.DataStorage;
using SSC.DataStorage.Interfaces;
using SSC.Forms.VSS.EditForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SSC.Forms.VSS
{
	public partial class VSS_Editor : Form
	{
		public VSS_Database DB_Clone { get; private set; }

		public VSS_Editor()
		{
			InitializeComponent();
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void VSS_Editor_Load(object sender, EventArgs e)
		{
			treeView_VSS_Options.BeginUpdate();
			treeView_VSS_Options.Nodes.Clear();
			DB_Clone = VSS_Database.Instance.Clone() as VSS_Database;
			PopulateTreeView(DB_Clone.VSS_RootNodes.Where(x => x != null).Select(x => x).ToList());
			treeView_VSS_Options.EndUpdate();
		}

		private void PopulateTreeView(List<IVSSRedeem> nodes, TreeNode parentNode = null)
		{
			foreach (IVSSRedeem node in nodes)
			{
				TreeNode treeNode = new TreeNode(node.VSS_Name)
				{
					Tag = node
				};

				if (parentNode == null)
					treeView_VSS_Options.Nodes.Add(treeNode);
				else
					parentNode.Nodes.Add(treeNode);

				if (node.VSS_Children != null)
				{
					var childeren = node.VSS_Children;
					if (childeren.Count == 0)
						continue;

					PopulateTreeView(childeren, treeNode);
				}

				if (node is VSS_Container)
				{
					var dat = node as VSS_Container;
					if (dat.IsExpended)
						treeNode.Expand();
					else
						treeNode.Collapse();
				}
			}
		}

		private void TB_MasterKey_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{

			}
		}

		private void addElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using AddVSSElementForm addForm = new();
			var result = addForm.ShowDialog();
			if (result != DialogResult.OK)
				return;

			var resultElement = addForm.GetResult();
			if (resultElement == null)
				return;

			if (resultElement is IVSSRedeem)
			{
				DB_Clone.VSS_TreeNodes.Add(resultElement);
				DB_Clone.VSS_Redeems_Dict.Add(resultElement.VSS_Guid, resultElement);

				if (treeView_VSS_Options.SelectedNode != null)
				{
					if (treeView_VSS_Options.SelectedNode.Tag is VSS_Container)
					{
						var containerCast = treeView_VSS_Options.SelectedNode.Tag as VSS_Container;
						containerCast.Append(resultElement);
						containerCast.IsExpended = true;
					}
				}
				else
				{
					DB_Clone.VSS_RootNodeGuids.Add(resultElement.VSS_Guid);
					DB_Clone.VSS_RootNodes.Add(resultElement);
				}
			}

			treeView_VSS_Options.BeginUpdate();
			treeView_VSS_Options.Nodes.Clear();
			PopulateTreeView(DB_Clone.VSS_RootNodes, null);
			treeView_VSS_Options.EndUpdate();
		}

		private void removeElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView_VSS_Options.SelectedNode != null)
			{
				var cast = treeView_VSS_Options.SelectedNode.Tag as IVSSRedeem;
				if (cast.VSS_Children?.Count > 0)
				{
					if (MessageBox.Show("Element you are trying to remove has children attached. Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
					{
						DB_Clone.RemoveElement(cast);
					}
				}
				else
					DB_Clone.RemoveElement(cast);
			}

			treeView_VSS_Options.BeginUpdate();
			treeView_VSS_Options.Nodes.Clear();
			PopulateTreeView(DB_Clone.VSS_RootNodes, null);
			treeView_VSS_Options.EndUpdate();
		}

		private void contextMenuTreeViewVSS_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (treeView_VSS_Options.SelectedNode != null)
				addElementToolStripMenuItem.Enabled = treeView_VSS_Options.SelectedNode.Tag is VSS_Container;
			else
				addElementToolStripMenuItem.Enabled = true;
		}

		private void treeView_VSS_Options_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null && e.Node.Tag is VSS_Container)
			{
				(e.Node.Tag as VSS_Container).IsExpended = true;
			}
		}

		private void treeView_VSS_Options_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null && e.Node.Tag is VSS_Container)
			{
				(e.Node.Tag as VSS_Container).IsExpended = false;
			}
		}
	}
}
