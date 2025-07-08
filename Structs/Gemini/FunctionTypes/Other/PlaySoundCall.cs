using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System.Linq;
using static SuiBot_TwitchSocket.API.EventSub.ES_ChannelPoints;

namespace SSC.Structs.Gemini.FunctionTypes.Other
{
	public class PlaySoundCall : FunctionCallSSC
	{
		[FunctionCallParameter(false)]
		public string Sound_Name;

		public override string FunctionName() => "play_sound_clip";
		public override string FunctionDescription() => "Plays a sound clip assuming if it finds it. If no sound name is provided, a list of sounds is returned";

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (MainForm.Instance.TwitchBot?.SndDB == null)
			{
				MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "Sounds rewards are currently not active.", Role.tool);
				return;
			}

			if (ChatBot.AreRedeemsPaused)
			{
				MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "Sounds rewards are currently paused.", Role.tool);
				return;
			}

			if (!string.IsNullOrEmpty(Sound_Name))
			{
				SoundStorage.SoundEntry reward = MainForm.Instance.TwitchBot.SndDB.SoundList.FirstOrDefault(x => x.RewardName == Sound_Name);
				if (reward == null)
					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "Provided sound seems missing. It might have been deleted.", Role.tool);
				else
					MainForm.Instance.TwitchBot.SndDB.PlaySound(message.chatter_user_id, reward);
			}
			else
			{
				var list = MainForm.Instance.TwitchBot.SndDB.GetList();
				if (list == null)
					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "List of sounds was empty.", Role.tool);
				else
					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, list, Role.tool);
			}
		}
	}
}
