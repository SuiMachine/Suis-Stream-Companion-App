using SSC.Chat;
using System;
using System.Text;

namespace SSC.Extensions
{
	public static class GeminiExtensions
	{
		public static void AppendStreamInstructionPostfix(this StringBuilder sb, bool attachIsLive)
		{
			sb.AppendLine("");

			if (attachIsLive)
			{
				ChannelInstance channelInstance = MainForm.Instance.TwitchBot.ChannelInstance;

				if (channelInstance.StreamStatus?.IsOnline ?? false)
				{

					sb.AppendLine($"{channelInstance.Channel} is now streaming {channelInstance.StreamStatus.game_name}.");
					sb.AppendLine($"The stream title is {channelInstance.StreamStatus.title}.");
				}
				else
				{
					sb.AppendLine($"{channelInstance.Channel} is currently not streaming any game.");
				}
			}
		}
	}
}
