using SSC.AI_Integration;
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
		private ReminderEntities closestReminder = null;
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

					if (m_AllChecked)
					{
						await Task.Delay(60_000);
						continue;
					}

					if (closestReminder == null)
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
								closestReminder = entity;
								m_AllChecked = false;
							}
						}

						if(closestReminder == null)
						{
							m_AllChecked = true;
							await Task.Delay(1000);
							continue;
						}
					}

					if (closestReminder.UTCTime < DateTime.UtcNow)
					{
						if (AI_Casual_Chats.Instance != null && false)
						{
							AI_Casual_Chats.Instance?.PassReminder(closestReminder);
						}
						else
						{
							ToastNotificationHelper.DisplayNotification(Path.Combine(AI_Casual_Chats.GetFolderAIData(), AIConfig.GetInstance().CasualChat_Icon_AI), closestReminder.Notification_Content, Windows.UI.Notifications.ToastTemplateType.ToastImageAndText01);
						}
						closestReminder.Notified = true;
						closestReminder = null;
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
				Save();
				m_AllChecked = false;
				closestReminder = null;
			}
		}
	}
}
