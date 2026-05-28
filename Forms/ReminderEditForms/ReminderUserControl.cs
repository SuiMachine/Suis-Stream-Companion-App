using System.Windows.Forms;

namespace SSC.OtherForms.ReminderEditForms
{
	public partial class ReminderUserControl : UserControl
	{
		private ReminderForm parent;
		private Reminders.ReminderEntities entity;
		public ReminderUserControl(ReminderForm parent, Reminders.ReminderEntities element)
		{
			this.parent = parent;
			this.entity = element;
			InitializeComponent();

			this.chk_Ack.Checked = entity.Acknowledged;
			this.dateTimeEntity.Value = entity.UTCTime.ToLocalTime();
			this.rb_Content.Text = element.Notification_Content;
		}

		private void B_Remove_Click(object sender, System.EventArgs e)
		{
			if (Reminders.GetInstance().Remove(entity))
				this.parent.ReloadList();
		}

		private void dateTimeEntity_ValueChanged(object sender, System.EventArgs e)
		{
			entity.UTCTime = this.dateTimeEntity.Value.ToUniversalTime();
		}

		private void chk_Ack_CheckedChanged(object sender, System.EventArgs e)
		{
			entity.Acknowledged = chk_Ack.Checked;
		}

		private void rb_Content_TextChanged(object sender, System.EventArgs e)
		{
			entity.Notification_Content = rb_Content.Text;
		}
	}
}
