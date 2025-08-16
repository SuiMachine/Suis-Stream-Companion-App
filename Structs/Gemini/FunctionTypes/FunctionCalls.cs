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

}
