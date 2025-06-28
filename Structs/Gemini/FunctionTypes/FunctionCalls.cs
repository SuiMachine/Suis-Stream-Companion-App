using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Text;
using static SuiBotAI.Components.Other.Gemini.GeminiTools;

namespace SSC.Structs.Gemini.FunctionTypes
{
	public abstract class FunctionCallSSC : FunctionCall
	{
		public virtual void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content) { }
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

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content)
		{
			if (message.UserRole >= ES_ChatMessage.Role.VIP)
			{
				channelInstance.UserTimeout(message, (uint)duration_in_seconds, text_response);
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

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content)
		{
			if (message.UserRole >= ES_ChatMessage.Role.VIP)
			{
				channelInstance.UserBan(message, text_response);
			}
		}
	}

	[Serializable]
	public class CurrentDateTimeCall : FunctionCallSSC
	{
		public override string FunctionName() => "Current_DateTime";
		public override string FunctionDescription() => "Obtains current date time (both local and UTC).";

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content)
		{
			System.Globalization.CultureInfo globalizationOverride = new System.Globalization.CultureInfo("en-US");

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Current local date is {DateTime.Now.ToString("MMMM d, yyy", globalizationOverride)} and time is {DateTime.Now.ToString("hh:mm:ss tt", globalizationOverride)}");
			sb.AppendLine($"Current UTC date is {DateTime.UtcNow.ToString("MMMM d, yyy", globalizationOverride)} and UTC time is {DateTime.UtcNow.ToString("hh:mm:ss tt", globalizationOverride)}");

			MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, sb.ToString());
		}
	}
}
