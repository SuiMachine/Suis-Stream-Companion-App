using SSC.DataStorage;
using SSC.DataStorage.Interfaces;
using SSC.Forms.VSS.EditForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SSC.Forms.VSS
{
	public partial class VSS_Editor : Form
	{
		private VSS_Database DB_Clone;

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
			PopulateTreeView(DB_Clone.VSS_TreeNodes.Where(x => x is IVSSRedeem).Select(x => x as IVSSRedeem).ToArray());
			treeView_VSS_Options.EndUpdate();
		}

		private void PopulateTreeView(IVSSRedeem[] nodes, TreeNode parentNode = null)
		{
			foreach (var node in nodes)
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
					if (childeren.Length == 0)
						continue;

					PopulateTreeView(childeren, treeNode);
				}
			}
		}

		private void TB_MasterKey_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void addElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using AddVSSElementForm addForm = new();
			var result = addForm.ShowDialog();
			if (result != DialogResult.OK)
				return;

			var resultElement = addForm.GetResult();
			if (resultElement.VSS_Children?.Length > 0)
			{

			}
		}

		private void removeElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (treeView_VSS_Options.SelectedNode != null)
			{
				if ((treeView_VSS_Options.SelectedNode.Tag as IVSSRedeem).VSS_Children?.Length > 0)
				{
					if (MessageBox.Show("Element you are trying to remove has children attached. Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
						treeView_VSS_Options.SelectedNode.Remove();
				}
				else
					treeView_VSS_Options.SelectedNode.Remove();
			}
		}
	}
}
