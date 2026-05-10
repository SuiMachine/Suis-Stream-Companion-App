using OBSWebsocketDotNet.Communication;
using OBSWebsocketDotNet.Types.Events;
using SSC.Properties;
using SuiBot_TwitchSocket.API.EventSub;
using System;
using System.Windows.Forms;

namespace SSC
{
	public class EventBridgeTwitch
	{
		public Action<ES_ChatMessage> OnChannelMessage;
		public Action<ES_ChannelPoints.ES_ChannelPointRedeemRequest> OnChannelPointsRedeem;
		public Action<ES_ChannelGoal> OnChannelGoalAchieved;
		public Action<ES_AdBreakBeginNotification> OnAdBreakStarted;
		public Action<ES_AdBreakBeginNotification, int> OnAdBreakFinished;
		public Action OnAdPrerollsActive;
		public Action<ES_ChannelRaid> OnChannelRaid;

		internal void Clear()
		{
			OnChannelMessage = null;
			OnChannelPointsRedeem = null;
			OnChannelGoalAchieved = null;
			OnAdBreakStarted = null;
			OnAdBreakFinished = null;
			OnAdPrerollsActive = null;
			OnChannelRaid = null;
		}
	}

	public class EventBridgeOBS
	{
		public Action OnOBSConnected;
		public Action OnOBSDisconnected;
		public Action<string> OnMediaSourceStoppedPlaying;

		internal void RegisterEvents(OBSWebsocketDotNet.OBSWebsocket OBS)
		{
			OBS.Connected += OBS_Connected;
			OBS.Disconnected += OBS_Disconnected;
			//OBS.ExitStarted += OBS_ExitStarted;
			OBS.MediaInputPlaybackEnded += OBS_MediaInputPlaybackEnded;
		}

		private void OBS_MediaInputPlaybackEnded(object sender, MediaInputPlaybackEndedEventArgs e)
		{
			OnMediaSourceStoppedPlaying?.Invoke(e.InputName);
		}

		private void OBS_Connected(object sender, EventArgs e)
		{
			MainForm.Instance.ThreadSafeAddPreviewText("OBS Connected", LineType.WebSocket);
			OnOBSConnected?.Invoke();
		}

		private void OBS_Disconnected(object sender, ObsDisconnectionInfo e)
		{
			MainForm.Instance.ThreadSafeAddPreviewText("OBS Disconnected", LineType.WebSocket);
			OnOBSDisconnected?.Invoke();
		}
	}
}
