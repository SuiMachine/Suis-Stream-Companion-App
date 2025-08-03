using System;
using System.Windows.Forms;

namespace SSC.OtherForms
{
	public partial class ReminderForm : Form
	{
		public static ReminderForm Instance { get; private set; } = null;

		public ReminderForm()
		{
			InitializeComponent();
		}

		private void ReminderForm_Load(object sender, EventArgs e)
		{
			Instance = this;
			ReloadList();
		}

		public void ReloadList()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(() =>
				{
					this.ReloadList();
				});
				return;
			}

			var reminders = Reminders.GetInstance();
			this.tableReminders.Hide();
			this.tableReminders.Controls.Clear();
			foreach (var element in reminders.Entities)
			{
				var newElement = new ReminderEditForms.ReminderUserControl(this, element);
				newElement.Dock = DockStyle.Fill;
				this.tableReminders.Controls.Add(newElement);
			}
			this.tableReminders.Show();
		}

		private void ReminderForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Instance == this)
				Instance = null;

		}

		private void B_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ReminderForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm.Instance.UpdateReminderIcon();
			Reminders.GetInstance().Rebuild();
		}
	}
}
