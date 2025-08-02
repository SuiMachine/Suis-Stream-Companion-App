using System;
using System.IO;
using System.Windows.Forms;

namespace SSC.AI_Integration
{
	public partial class NotesForm : Form
	{
		public static NotesForm Instance { get; private set; }
		private Notes notesUsed;

		public NotesForm()
		{
			InitializeComponent();
		}

		private void NotesForm_Load(object sender, System.EventArgs e)
		{
			if (Instance == null)
				Instance = this;
			notesUsed = Notes.GetInstance();


			this.Rebuild();
		}

		public void Rebuild()
		{
			if(this.InvokeRequired)
			{
				this.Invoke(Rebuild);
				return;
			}

			this.chkList_Notes.Items.Clear();
			foreach (var note in notesUsed.CurrentNotes)
			{
				this.chkList_Notes.Items.Add(note.Content, note.Completed);
			}
		}

		private void NotesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			notesUsed?.Save();
		}

		private void NotesForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (Instance == this)
				Instance = null;
		}

		private void openToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			var openFile = new OpenFileDialog()
			{
				InitialDirectory = Directory.GetParent(Notes.DefaultNotesPath()).FullName,
				Filter = "Notes files | *.SSCNote"
			};
			var result = openFile.ShowDialog();
			if (result == DialogResult.OK)
			{
				notesUsed.Open(openFile.FileName);
				Rebuild();
			}
		}

		private void chkList_Notes_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var id = e.Index;
			this.notesUsed.CurrentNotes[id].Completed = e.NewValue == CheckState.Checked;
			this.notesUsed.Save();
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.notesUsed.CurrentNotes.RemoveAt(chkList_Notes.SelectedIndex);
			this.notesUsed.Save();
			this.Rebuild();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var saveFiles = new SaveFileDialog()
			{
				InitialDirectory = Directory.GetParent(Notes.DefaultNotesPath()).FullName,
				Filter = "Notes files | *.SSCNote"
			};
			if (saveFiles.ShowDialog() == DialogResult.OK)
			{
				this.notesUsed.SaveAs(saveFiles.FileName);
			}
		}

		private void addEntityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var form = new SSC.OtherForms.Notes.AddEditNotes();
			var dlg = form.ShowDialog();
			if (dlg == DialogResult.OK)
			{
				notesUsed.CurrentNotes.Add(form.Entity);
				notesUsed.Save();
				Rebuild();
			}
		}

		private void editEntityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var index = chkList_Notes.SelectedIndex;
			if (index == -1)
				return;
			var entity = notesUsed.CurrentNotes[index];

			var form = new SSC.OtherForms.Notes.AddEditNotes(entity);
			var dlg = form.ShowDialog();
			if (dlg == DialogResult.OK)
			{
				notesUsed.Save();
				Rebuild();
			}
		}
	}
}
