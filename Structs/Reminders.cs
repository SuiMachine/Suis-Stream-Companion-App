using SSC.AI_Integration;
using SSC.OtherForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SSC
{
	public class Reminders : IDisposable
	{
		internal static string DefaultNotesPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "Notes", "Main.SSCReminders");
		private static Reminders m_Instance;
		private Task m_TickCounter;
		private CancellationTokenSource cancelationSource;
		private bool m_AllChecked;
		public ReminderEntities ClosestReminder { get; private set; } = null;
		public static Reminders GetInstance()
		{
			if (m_Instance == null)
			{
				m_Instance = new Reminders();
			}
			return m_Instance;
		}

		public void Dispose()
		{
			cancelationSource?.Cancel();
		}

		private Reminders()
		{
			Entities = XML_Utils.Load(DefaultNotesPath(), new List<ReminderEntities>());

			cancelationSource = new CancellationTokenSource();
			m_TickCounter = Task.Run(async () =>
			{
				while (true)
				{
					if (cancelationSource.IsCancellationRequested)
					{
						cancelationSource.Dispose();
						return;
					}

					//Block it!
					if (ReminderForm.Instance != null)
					{
						await Task.Delay(1_000);
						continue;
					}

					if (m_AllChecked)
					{
						await Task.Delay(60_000);
						continue;
					}

					if (ClosestReminder == null)
					{
						if (Entities.Count == 0)
						{
							m_AllChecked = true;
							await Task.Delay(1000);
							continue;
						}

						DateTime closestReminderDT = DateTime.MaxValue;
						foreach (var entity in Entities)
						{
							if (entity.Notified)
								continue;

							if (entity.UTCTime < closestReminderDT)
							{
								closestReminderDT = entity.UTCTime;
								ClosestReminder = entity;
								m_AllChecked = false;
							}
						}

						if (ClosestReminder == null)
						{
							m_AllChecked = true;
							await Task.Delay(1000);
							continue;
						}
					}

					if (ClosestReminder.UTCTime < DateTime.UtcNow)
					{
						if (AI_Casual_Chats.Instance != null && false)
						{
							AI_Casual_Chats.Instance?.PassReminder(ClosestReminder);
						}
						else
						{
							ToastNotificationHelper.DisplayNotification(Path.Combine(AI_Casual_Chats.GetFolderAIData(), AIConfig.GetInstance().CasualChat_Icon_AI), ClosestReminder.Notification_Content, Windows.UI.Notifications.ToastTemplateType.ToastImageAndText01);
						}
						MainForm.Instance.UpdateReminderIcon();
						ClosestReminder.Notified = true;
						ClosestReminder = null;
						m_AllChecked = false;
						Save();
					}

					await Task.Delay(1000);
				}
			}, cancelationSource.Token);
		}

		public class ReminderEntities
		{
			[XmlAttribute] public Guid UID;
			[XmlAttribute] public bool Notified;
			[XmlAttribute] public bool Acknowledged;
			[XmlAttribute] public DateTime UTCTime;
			[XmlText] public string Notification_Content;

			public ReminderEntities()
			{
				UID = Guid.NewGuid();
				Notified = false;
				Acknowledged = false;
				UTCTime = DateTime.UtcNow;
				Notification_Content = "";
			}

			public ReminderEntities(DateTime utcTime, string text)
			{
				UID = Guid.NewGuid();
				this.Notified = false;
				this.Acknowledged = false;
				this.UTCTime = utcTime;
				this.Notification_Content = text;
			}
		}

		private void Save()
		{
			XML_Utils.Save(DefaultNotesPath(), Entities);
		}

		public List<ReminderEntities> Entities { get; private set; } = new();

		public void AddReminder(DateTime utcTime, string text)
		{
			lock (Entities)
			{
				Entities.Add(new ReminderEntities(utcTime, text));
				Entities = Entities.OrderBy(x => x.UTCTime).ToList();
				Save();
				m_AllChecked = false;
				ClosestReminder = null;
			}
		}

		internal bool Remove(ReminderEntities entity)
		{
			bool result = Entities.Remove(entity);
			if (result)
			{
				if (ClosestReminder == entity)
				{
					ClosestReminder = null;
					m_AllChecked = false;
				}
				Save();
			}
			return result;
		}

		internal void Rebuild()
		{
			this.ClosestReminder = null;
			m_AllChecked = false;
			Entities = Entities.OrderBy(x => x.UTCTime).ToList();
			Save();
		}
	}
}
