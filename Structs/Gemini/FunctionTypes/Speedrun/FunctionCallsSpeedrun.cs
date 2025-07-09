using SpeedrunComSharp;
using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Linq;
using System.Text;

namespace SSC.Structs.Gemini.FunctionTypes.Speedrun
{
	[Serializable]
	public class SpeedrunWRCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string game_name = null;
		[FunctionCallParameter(false)]
		public string category = null;

		public override string FunctionName() => "speedrun_world_record";

		public override string FunctionDescription() => "Gets best time (world record) speedrunning leaderboard if it exists";

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content)
		{
			if (game_name == null)
				return;
			var speedrunClient = new SpeedrunComClient();
			var game = speedrunClient.Games.SearchGame(game_name);
			if (game == null)
				MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "No game was found.", SuiBotAI.Components.Other.Gemini.Role.tool);
			else
			{
				var categories = game.FullGameCategories;

				var foundCategory = string.IsNullOrEmpty(category) ? null : categories.FirstOrDefault(x => x.Name == category);

				if (string.IsNullOrEmpty(category) || foundCategory == null)
				{
					StringBuilder sb = new StringBuilder();

					if (!string.IsNullOrEmpty(category))
					{
						sb.AppendLine("Incorrect category name");
						sb.AppendLine("");
					}

					sb.AppendLine("Available categories are:");
					foreach (var category in categories)
					{
						sb.AppendLine($"* {category.Name}");
					}
					sb.AppendLine($"The default category is: {game.FullGameCategories.ElementAt(0)}");
					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, sb.ToString(), SuiBotAI.Components.Other.Gemini.Role.tool);
				}
				else
				{
					StringBuilder sb = new StringBuilder();
					if (foundCategory.WorldRecord != null)
						sb.AppendLine($"Best time for {foundCategory.Name} is {foundCategory.WorldRecord.Times.Primary.Value} by {foundCategory.WorldRecord.Player.Name}.");
					else
						sb.AppendLine($"Category {foundCategory.Name} doesn't have any records.");

					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, sb.ToString(), SuiBotAI.Components.Other.Gemini.Role.tool);
				}
			}
		}
	}

	[Serializable]
	public class SpeedrunPBCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string username = null;
		[FunctionCallParameter(true)]
		public string game_name = null;
		[FunctionCallParameter(false)]
		public string category = null;

		public override string FunctionDescription() => "Gets user's personal best from speedrunning leaderboard if it exists";

		public override string FunctionName() => "speedrun_personal_best";

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, SuiBotAI.Components.Other.Gemini.GeminiContent content)
		{
			if (game_name == null)
				return;
			var speedrunClient = new SpeedrunComClient();
			var game = speedrunClient.Games.SearchGame(game_name);
			if (game == null)
				MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, "No game was found.", SuiBotAI.Components.Other.Gemini.Role.tool);
			else
			{
				var categories = game.FullGameCategories;

				var foundCategory = string.IsNullOrEmpty(category) ? null : categories.FirstOrDefault(x => x.Name == category);

				if (category == null || foundCategory == null)
				{
					StringBuilder sb = new StringBuilder();
					if (category != null)
					{
						sb.AppendLine("Invalid category name!");
						sb.AppendLine("");
					}

					sb.AppendLine("Available categories are:");
					foreach (var category in categories)
					{
						sb.AppendLine($"* {category.Name}");
					}
					sb.AppendLine($"The default category is: {game.FullGameCategories.ElementAt(0)}");
					MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, sb.ToString(), SuiBotAI.Components.Other.Gemini.Role.tool);
				}
				else
				{
					var pbs = speedrunClient.Users.GetPersonalBests(username, gameId: game.ID);
					if (pbs.Count == 0)
					{
						string response = $"{username} has not done any runs in this game.";
						MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, response, SuiBotAI.Components.Other.Gemini.Role.tool);
						return;
					}

					var matchingPB = pbs.FirstOrDefault(x => x.CategoryID == foundCategory.ID);
					if (matchingPB == null)
					{
						string response = $"{username} has not done any runs in category {foundCategory.Name}.";
						MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, response, SuiBotAI.Components.Other.Gemini.Role.tool);
					}
					else
					{
						string response = $"{username} best time in {foundCategory.Name} is {matchingPB.Times.Primary.Value}.";

						MainForm.Instance?.AI?.GetSecondaryAnswer(channelInstance, message, content, response, SuiBotAI.Components.Other.Gemini.Role.tool);
					}
				}
			}
		}
	}
}
