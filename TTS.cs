using KokoroSharp;
using KokoroSharp.Core;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSC
{
	public class TTS
	{
		private KokoroTTS processor;
		private KokoroVoice voice;
		private static TTS m_tts = null;
		private Task SpeechTask;
		private volatile Queue<string> MessageQueue = new Queue<string>();

		public static TTS GetInstance()
		{
			if (m_tts == null)
				m_tts = new TTS();

			return m_tts;
		}

		private TTS()
		{
			processor = KokoroTTS.LoadModel();
			voice = KokoroVoiceManager.GetVoice("af_bella");
		}

		public void StripMarkdownAndEnqueue(string message)
		{
			message = message.Replace("<3", "");
			message = message.Replace(",", "");
			message = message.Replace("\"", "");
			message = message.Replace("*", "");
			message = message.Replace("Sia", "[Sia](/ssɪɪa/)"); //This should be I think split into words and replaced as words.

			//Regex reg = new Regex("[\\*].+?[\\*]");
			//message = reg.Replace(message, "");

			Enqueue(message);
		}

		public void Enqueue(string message)
		{
			MessageQueue.Enqueue(message);

			if (SpeechTask?.IsCompleted ?? true)
			{
				SpeechTask = Task.Run(async () =>
				{
					while (MessageQueue.Count > 0)
					{
						var msg = MessageQueue.Dequeue();
						var handle = processor.SpeakFast(msg, voice, new KokoroSharp.Processing.KokoroTTSPipelineConfig()
						{
							PreprocessText = true,
							SecondsOfPauseBetweenProperSegments = new KokoroSharp.Processing.PauseAfterSegmentStrategy(CommaPause: 0.09f, PeriodPause: 0.4f, ExclamationMarkPause: 0.5f, OthersPause: 0.3f),
							Speed = 1.1f
						});
						bool cancelled = false;
						bool completed = false;
						handle.OnSpeechCompleted += (b) =>
						{
							completed = true;
						};
						handle.OnSpeechCanceled += (b) =>
						{
							cancelled = true;
						};

						while (!completed)
						{
							if (cancelled)
								return;
							await Task.Delay(250);
						}
					}
				});
			}
		}
	}
}
