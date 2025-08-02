using SSC.AI_Integration;
using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Structs.Gemini.FunctionTypes
{
	public class GetMessageCountGeminiCall : FunctionCallSSC
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

	public class AddANoteGeminiCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_Content;

		public override string FunctionDescription() => $"Adds a note to database that is accessible for both the AI and user.";

		public override string FunctionName() => "AddANote";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if(string.IsNullOrEmpty(Note_Content))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Noted content can not be null or empty!"));
				return;
			}



			lock (Notes.GetInstance().CurrentNotes)
			{
				Notes.GetInstance().CurrentNotes.Add(new Notes.NotesEntity()
				{
					Completed = false,
					Content = Note_Content
				});
				Notes.GetInstance().Save();
			}

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Added a note"));

			if(NotesForm.Instance != null)
			{
				NotesForm.Instance.Rebuild();
			}
		}
	}

	public class GetAllNotesGeminiCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string Note_Content;

		public override string FunctionDescription() => $"Gets a list of current notes. This is to be used as a way for AI to find something in notes - AI is not supposed to send them all to a user, unless a user specifically asks for a full list.";

		public override string FunctionName() => "GetAllNotes";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			StringBuilder sb = new StringBuilder();

			lock (Notes.GetInstance().CurrentNotes)
			{
				foreach(var note in Notes.GetInstance().CurrentNotes)
				{
					if (string.IsNullOrEmpty(note.Content))
						continue;

					sb.AppendLine("- " + note.Content);
					sb.AppendLine();
				}
			}

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), sb.ToString()));

			if (NotesForm.Instance != null)
			{
				NotesForm.Instance.Rebuild();
			}
		}
	}
}
