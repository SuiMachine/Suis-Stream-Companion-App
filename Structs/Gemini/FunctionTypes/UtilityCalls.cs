using CefSharp.DevTools.DOM;
using Newtonsoft.Json;
using SSC.AI_Integration;
using SSC.Chat;
using SSC.OtherForms;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace SSC.Structs.Gemini.FunctionTypes
{
	public class GetMessageCountAICall : FunctionCallSSC
	{
		public override string FunctionDescription() => $"Returns the amount of messages, message parts and attachments currently stored in conversation.";

		public override string FunctionName() => "GetConversationInformation";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			int messageCount = 0;
			int partsCount = 0;

			StringBuilder sb = new StringBuilder();
			foreach (var msg in content.contents)
			{
				foreach (var part in msg.parts)
				{
					partsCount++;
				}
				messageCount++;
			}

			sb.AppendLine($"Message count: {messageCount}");
			sb.AppendLine($"Message parts (total): {partsCount}");


			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), sb.ToString()));
		}
	}

	public class AddANoteAICall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_Content;

		public override string FunctionDescription() => $"Adds a note to database that is accessible for both the AI and user.";

		public override string FunctionName() => "AddANote";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (string.IsNullOrEmpty(Note_Content))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Noted content can not be null or empty!"));
				return;
			}



			lock (Notes.GetInstance().CurrentNotes)
			{
				Notes.GetInstance().CurrentNotes.Add(new Notes.NotesEntity()
				{
					UID = new Guid(),
					Completed = false,
					Content = Note_Content
				});
				Notes.GetInstance().Save();
			}

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Added a note"));

			if (NotesForm.Instance != null)
			{
				NotesForm.Instance.Rebuild();
			}
		}
	}

	public class EditANoteAICall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_ID;
		[FunctionCallParameter(false)]
		public bool? Completed;
		[FunctionCallParameter(false)]
		public string Content;

		public override string FunctionDescription() => $"Edits a note in database. Only Note_ID argument is required. Other arguments should only be provided if changes to them were made.";

		public override string FunctionName() => "EditANote";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (Note_ID == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Noted ID is required!"));
				return;
			}

			if (!Guid.TryParse(Note_ID, out Guid parseID))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Failed to parse note ID."));
				return;
			}

			var notes = Notes.GetInstance().CurrentNotes;

			Notes.NotesEntity foundNote = null;
			lock (notes)
			{
				foreach (var note in notes)
				{
					if (note.UID == parseID)
					{
						foundNote = note;
						break;
					}
				}
			}

			if (foundNote != null)
			{
				if (Completed != null)
					foundNote.Completed = Completed.Value;

				if (Content != null)
					foundNote.Content = Content;

				Notes.GetInstance().Save();
				NotesForm.Instance?.Rebuild();

				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Updated a note {foundNote.UID}."));
			}
			else
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Couldn't find a note with this ID - it was probably already deleted."));
			}
		}
	}

	public class RemoveANoteAICall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_ID;

		public override string FunctionDescription() => $"Removes a note from database. Note_ID is requires and can be obtained by AI by getting a list of notes with GetAllNotes.";

		public override string FunctionName() => "RemoveANote";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (Note_ID == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Noted ID is required!"));
				return;
			}

			if (!Guid.TryParse(Note_ID, out Guid parseID))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Failed to parse note ID."));
				return;
			}

			var notes = Notes.GetInstance().CurrentNotes;

			Notes.NotesEntity foundNote = null;
			lock (notes)
			{
				foreach (var note in notes)
				{
					if (note.UID == parseID)
					{
						foundNote = note;
						notes.Remove(note);
						break;
					}
				}
			}

			if (foundNote != null)
			{
				Notes.GetInstance().Save();
				NotesForm.Instance?.Rebuild();

				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Removed note {foundNote.UID}: {foundNote.Content}"));
			}
			else
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Couldn't find a note with this ID - it was probably already deleted."));
			}
		}
	}

	public class GetAllNotesAICall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_Content;

		public override string FunctionDescription() => $"Gets a list of current notes. This is to be used as a way for AI to find something in notes - AI is not supposed to send them all to a user, unless a user specifically asks for a full list.";

		public override string FunctionName() => "GetAllNotes";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), JsonConvert.SerializeObject(Notes.GetInstance().CurrentNotes, Formatting.Indented)));
			NotesForm.Instance?.Rebuild();
		}
	}

	public class AddReminderAICall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string DateTime_UTC;

		[FunctionCallParameter(true)]
		public string Reminder_Text;

		public override string FunctionName() => "AddReminder";

		public override string FunctionDescription() => "Adds a reminder. DateTime_UTC needs to be in a format \"yyy-MM-dd HHH:mm:ss\" format and in UTC time (identical to User's timestamp message tag).";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (DateTime_UTC == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "DateTime_UTC can not be null"));
				return;
			}

			if (!DateTime.TryParse(DateTime_UTC, out DateTime parsedDateTime))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Failed to parse DateTime_UTC"));
				return;
			}

			if (Reminder_Text == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Reminder_Text can not be null"));
				return;
			}

			Reminders.GetInstance().AddReminder(parsedDateTime, Reminder_Text);
			var globalizationOverride = CultureInfo.GetCultureInfo("en-US");
			ReminderForm.Instance?.ReloadList();

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Added a reminder on {parsedDateTime.ToString("yyy-MM-dd", globalizationOverride)} {parsedDateTime:HH:mm:ss}Z"));
		}
	}

	public class DisplaySystemNotificationCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Notification_Text;

		public override string FunctionDescription() => $"Displays a notification in the system.";

		public override string FunctionName() => "DisplaySystemNotification";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (string.IsNullOrEmpty(Notification_Text))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Notification_Text can not be empty!"));
				return;
			}

			ToastNotificationHelper.DisplayNotification(System.IO.Path.Combine(AI_Casual_Chats.GetFolderAIData(), AIConfig.GetInstance().CasualChat_Icon_AI), Notification_Text, ToastTemplateType.ToastImageAndText02);

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Notification sent to system!"));
		}
	}
}
