using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System.Linq;
using System.Threading.Tasks;
using static SuiBot_TwitchSocket.API.EventSub.ES_ChannelPoints;

namespace SSC.Structs.Gemini.FunctionTypes.Other
{
	public class PlaySoundCall : FunctionCallSSC
	{
		[FunctionCallParameter(false)]
		public string Sound_Name;

		public override string FunctionName() => "play_sound_clip";
		public override string FunctionDescription() => "Plays a sound clip assuming if it finds it. If no sound name is provided, a list of sounds is returned";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (MainForm.Instance.TwitchBot?.SndDB == null)
			{
				await MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Sounds rewards are currently not active."));
				return;
			}

			if (ChatBot.AreRedeemsPaused)
			{
				await MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Sounds rewards are currently paused."));
				return;
			}

			if (!string.IsNullOrEmpty(Sound_Name))
			{
				SoundStorage.SoundEntry reward = MainForm.Instance.TwitchBot.SndDB.SoundList.FirstOrDefault(x => x.RewardName == Sound_Name);
				if (reward == null)
					await MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Provided sound seems missing. It might have been deleted."));
				else
					MainForm.Instance.TwitchBot.SndDB.PlaySound(message.chatter_user_id, reward);
			}
			else
			{
				var list = MainForm.Instance.TwitchBot.SndDB.GetList();
				if (list == null)
					await MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "List of sounds was empty."));
				else
					await MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), list));
			}
		}
	}
}
