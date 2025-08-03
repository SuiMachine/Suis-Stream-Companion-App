using System;
using System.Windows.Forms;

namespace SSC.OtherForms.Notes
{
	public partial class AddEditNotes : Form
	{
		public Structs.Notes.NotesEntity Entity { get; private set; }

		public AddEditNotes()
		{
			this.Entity = new Structs.Notes.NotesEntity();
			InitializeComponent();
			this.Text = "Add entry";
		}

		public AddEditNotes(Structs.Notes.NotesEntity entity)
		{
			this.Entity = entity;
			InitializeComponent();
			this.Text = "Edit entry";
		}

		private void AddEditNotes_Load(object sender, EventArgs e)
		{
			this.rbText_Note.Text = Entity.Content;
			this.CB_Completed.Checked = Entity.Completed;
		}

		private void B_OK_Click(object sender, EventArgs e)
		{
			Entity.Completed = CB_Completed.Checked;
			Entity.Content = this.rbText_Note.Text;
			this.DialogResult = DialogResult.OK;
		}

		private void B_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
