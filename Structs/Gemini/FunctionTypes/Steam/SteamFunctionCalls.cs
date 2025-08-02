using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSC.Chat;
using SuiBot_TwitchSocket;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SSC.Structs.Gemini.FunctionTypes.Steam
{
	public class SteamGetAppIDsForNameCalls : FunctionCallSSC
	{
		public static SteamAppAppList.SteamAppData[] data;

		[FunctionCallParameter(true)]
		public string Game_Name;

		public override string FunctionDescription() => "Looks for a game name in Steam Database and returns matching IDs which then can be used to obtain information about the game from Store page";

		public override string FunctionName() => "GetSteamAppIDs";

		public class SteamAppAppList
		{
			public SteamAppDataContainer applist;

			public class SteamAppDataContainer
			{
				public SteamAppData[] apps;
			}

			[DebuggerDisplay("{name} ({appid})")]
			public class SteamAppData
			{
				public ulong appid = 0;
				public string nameLowerCase = "";
				public string name = "";
			}
		}

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (string.IsNullOrEmpty(Game_Name))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Game_Name can not be null or empty!"));
				return;
			}

			if (data == null)
			{
				var games = await HttpWebRequestHandlers.PerformGetAsync("https://api.steampowered.com/", "ISteamApps/GetAppList/v2/", "", [], 25000);
				var converted = JsonConvert.DeserializeObject<SteamAppAppList>(games);
				data = converted.applist.apps;
				foreach (var element in data)
				{
					if (element.name != null)
					{
						element.nameLowerCase = element.name.Trim().ToLower();
					}
				}
			}

			var nameToLower = Game_Name.ToLower().Trim();

			List<SteamAppAppList.SteamAppData> finds = new List<SteamAppAppList.SteamAppData>();
			foreach (var element in data)
			{
				if (element.nameLowerCase == null)
					continue;

				if (element.nameLowerCase == nameToLower)
				{
					finds.Add(element);
				}
			}
			if (finds.Count > 0)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), JsonConvert.SerializeObject(finds, Formatting.Indented)));
				return;
			}

			foreach (var element in data)
			{
				if (element.nameLowerCase == null)
					continue;

				if (element.nameLowerCase.Contains(nameToLower))
				{
					finds.Add(element);
				}
			}

			if (finds.Count > 0)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), JsonConvert.SerializeObject(finds, Formatting.Indented)));
				return;
			}

			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Nothing found"));
		}
	}

	public class SteamGetAppIDDataCalls : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string AppID;

		public override string FunctionDescription() => "Downloads description of a Steam store page for given App ID. App ID can be found using SteamGetAppIDsForNameCalls function.";

		public override string FunctionName() => "GetSteamAppIdInfo";

		public class SteamAppData
		{
			public class SteamAppRequirements
			{
				public string minimum;
				public string recommended;
			}

			public class SteamAppStorePriceOverview
			{
				public string currency;
				public int initial;
				public int final;
				public float discount_percent;
				public string initial_formatted;
				public string final_formatted;
			}

			public string type;
			public string name;
			public ulong steam_appid;
			public string required_age;
			public bool is_free = false;
			public ulong[] dlc;
			public string detailed_description;
			public string about_the_game;
			public string short_description;
			public string website;
			public SteamAppRequirements pc_requirements;
			public string[] developers;
			public string[] publishers;
			public SteamAppStorePriceOverview price_overview;
		}

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			if (string.IsNullOrEmpty(AppID))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "AppID is required!"));
				return;
			}

			var result = await HttpWebRequestHandlers.PerformGetAsync("https://store.steampowered.com/", "api/appdetails", $"?appids={AppID}", [], 25000);
			if(string.IsNullOrEmpty(result))
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Failed to download data for AppID {AppID}!"));
				return;
			}

			var deserialize = (JToken)JsonConvert.DeserializeObject(result);
			if(deserialize.Count() == 0 || deserialize[AppID] == null )
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Failed to download data for AppID {AppID}!"));
				return;
			}

			var success = deserialize[AppID]["success"].ToObject<bool>();
			if(!success)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), $"Failed to download data for AppID {AppID}!"));
				return;
			}

			var data = deserialize[AppID]["data"].ToObject<SteamAppData>();
			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), JsonConvert.SerializeObject(data, Formatting.Indented)));
		}
	}

}
