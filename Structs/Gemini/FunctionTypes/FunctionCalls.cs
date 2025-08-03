using Newtonsoft.Json;
using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Text;
using System.Threading.Tasks;
using static SuiBotAI.Components.Other.Gemini.GeminiTools;

namespace SSC.Structs.Gemini.FunctionTypes
{
	public abstract class FunctionCallSSC : FunctionCall
	{
		public virtual async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content) { await Task.Delay(1); }
	}

	[Serializable]
	public class TimeOutUserCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public double duration_in_seconds = 1;
		[FunctionCallParameter(false)]
		public string text_response = null;

		public override string FunctionName() => "Timeout_User";
		public override string FunctionDescription() => "Time outs a user in the chat. text_response can not be longer than 350 characters.";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (message.UserRole >= ES_ChatMessage.Role.VIP)
			{
				channelInstance.UserTimeout(message, (uint)duration_in_seconds, text_response);
				await Task.Delay(1);
			}
		}
	}

	[Serializable]
	public class BanUserCall : FunctionCallSSC
	{
		[FunctionCallParameter(false)]
		public string text_response = null;

		public override string FunctionName() => "Ban_User";
		public override string FunctionDescription() => "Bans a user. text_response can not be longer than 350 characters.";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (message.UserRole >= ES_ChatMessage.Role.VIP)
			{
				channelInstance.UserBan(message, text_response);
				await Task.Delay(1);
			}
		}
	}

	[Serializable]
	public class CurrentDateTimeCall : FunctionCallSSC
	{
		public override string FunctionName() => "Current_DateTime";
		public override string FunctionDescription() => "Obtains current date time (both local and UTC).";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			System.Globalization.CultureInfo globalizationOverride = new System.Globalization.CultureInfo("en-US");

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Current local date is {DateTime.Now.ToString("MMMM d, yyy", globalizationOverride)} and time is {DateTime.Now.ToString("hh:mm:ss tt", globalizationOverride)}");
			sb.AppendLine($"Current UTC date is {DateTime.UtcNow.ToString("MMMM d, yyy", globalizationOverride)} and UTC time is {DateTime.UtcNow.ToString("hh:mm:ss tt", globalizationOverride)}");

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), sb.ToString()));
		}
	}

	[Serializable]
	public class GetChatHistoryCall : FunctionCallSSC
	{
		public override string FunctionName() => "GetChatHistory";
		public override string FunctionDescription() => "Gets the recent chat history (up to 100 messages) - it contains MessageID (unique ID of a message), Chatter_User_ID (User ID), user Chatter_Login (used in URLs), Chatter_Name (Display name and a way user is suppose to be referred to) and actual content of a message. **AI must never post a full chat history in responses**";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			var inst = MainForm.Instance.TwitchBot?.ChannelInstance;
			if(inst == null || !inst.ConnectedStatus)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "You are currently not connected to the chat."));
				return;
			}


			var result = JsonConvert.SerializeObject(inst.LastMessages, Formatting.Indented);
			if (channelInstance == null || !channelInstance.ConnectedStatus)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), result));
				return;
			}
		}
	}
}
