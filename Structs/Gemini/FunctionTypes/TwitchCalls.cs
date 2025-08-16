using Newtonsoft.Json;
using SSC.Chat;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Threading.Tasks;

namespace SSC.Structs.Gemini.FunctionTypes
{
	[Serializable]
	public class GetChatUsersCall : FunctionCallSSC
	{
		public override string FunctionName() => "GetChatUsers";
		public override string FunctionDescription() => "Gets a list of chat users. This list should never be used in text response and should only be used as data for further requests.";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			channelInstance ??= MainForm.Instance.TwitchBot?.ChannelInstance;
			if (channelInstance == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "You are currently not connected to a chat."));
				return;
			}

			SuiBot_TwitchSocket.API.Helix.Responses.Response_GetChatters response = await channelInstance.GetChatters();
			if (response == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "Failed to get the list of chatters."));
				return;
			}

			var r = JsonConvert.SerializeObject(response, Formatting.Indented); //A bit stupid that we deserialize it and serialize it again
			await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), r));
		}
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
	public class TimeOutSpecificUserCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public double duration_in_seconds = 1;
		[FunctionCallParameter(true)]
		public string user_id = null;
		[FunctionCallParameter(false)]
		public string text_response = null;

		public override string FunctionName() => "Timeout_Specific_User";
		public override string FunctionDescription() => "Timeouts a specific user in the chat. user_id and duration_in_seconds are required, text_response is optional and can not be longer than 350 characters.";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			channelInstance ??= MainForm.Instance.TwitchBot?.ChannelInstance;
			if (channelInstance == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "You are currently not connected to a chat."));
				return;
			}

			if (user_id == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "user_id is required!"));
				return;
			}

			var userInfo = await channelInstance.GetUserInfo(user_id);
			if (userInfo == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "User with this ID doesn't exists!"));
				return;
			}

			channelInstance.UserTimeout(message.broadcaster_user_id, user_id, (uint)duration_in_seconds, text_response);
			await Task.Delay(1);
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
	public class BanSpecificUserCall : FunctionCallSSC
	{
		[FunctionCallParameter(true)]
		public string user_id = null;
		[FunctionCallParameter(false)]
		public string text_response = null;

		public override string FunctionName() => "Ban_Specific_User";
		public override string FunctionDescription() => "Bans a specific user in the chat. user_id is required, text_response is optional and can not be longer than 350 characters.";

		public override async Task Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			channelInstance ??= MainForm.Instance.TwitchBot?.ChannelInstance;
			if (channelInstance == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "You are currently not connected to a chat."));
				return;
			}

			if (user_id == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "user_id is required!"));
				return;
			}

			var userInfo = await channelInstance.GetUserInfo(user_id);
			if (userInfo == null)
			{
				await MainForm.Instance.AI.GetSecondaryAnswer(channelInstance, message, content, GeminiMessage.CreateFunctionCallResponse(FunctionName(), "User with this ID doesn't exists!"));
				return;
			}

			channelInstance.UserBan(message.broadcaster_user_id, user_id, text_response);
			await Task.Delay(1);
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
			if (inst == null || !inst.ConnectedStatus)
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
