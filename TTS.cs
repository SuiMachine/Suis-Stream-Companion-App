using NAudio.Wave;
using PiperSharp;
using PiperSharp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SSC
{
	public class TTS
	{

		private static TTS m_tts = null;
		private Task SpeechTask;
		private volatile Queue<string> MessageQueue = new Queue<string>();
		private Task DownloadingTask;
		private PiperWaveProvider piperModel;

		public static TTS GetInstance()
		{
			if (m_tts == null)
				m_tts = new TTS();

			return m_tts;
		}

		private TTS()
		{
			const string ModelKey = "en_US-amy-medium";

			var cwd = Directory.GetCurrentDirectory();
			string ModelPath = Path.Combine(cwd, "CurrentModel");
			DownloadingTask = Task.Run(async () =>
			{
				//Based on example code
				if (!File.Exists(PiperDownloader.DefaultPiperExecutableLocation))
				{
					await PiperDownloader.DownloadPiper().ExtractPiper(PiperDownloader.DefaultLocation);
				}

				var modelPath = Path.Join(PiperDownloader.DefaultModelLocation, ModelKey);
				VoiceModel? model = null;
				if (Directory.Exists(modelPath))
					model = await VoiceModel.LoadModelByKey(ModelKey);
				else
					model = await PiperDownloader.DownloadModelByKey(ModelKey);

				var playbackThread = new Thread(PlaybackThread);
				piperModel = new PiperWaveProvider(new PiperConfiguration()
				{
					Model = model,
					UseCuda = false
				});
				piperModel.Start();
				playbackThread.Start(piperModel);
			});
		}

		public void PlaybackThread(object? obj)
		{
			var provider = (PiperWaveProvider)obj!;
			using (var outputDevice = new WaveOutEvent())
			{
				outputDevice.Init(provider);
				outputDevice.Play();
				while (outputDevice.PlaybackState == PlaybackState.Playing)
				{
					Thread.Sleep(1000);
				}
			}
		}

		public void StripMarkdownAndEnqueue(string message)
		{
			message = message.Replace("<3", "");
			//message = message.Replace(",", "");
			//message = message.Replace("\"", "");		



			//Regex reg = new Regex("[\\*].+?[\\*]");
			//message = reg.Replace(message, "");

			Enqueue(message);
		}

		public void Enqueue(string message)
		{
			MessageQueue.Enqueue(message);

			if(SpeechTask?.IsCompleted ?? true)
			{
				SpeechTask = Task.Run(async () =>
				{
					while (!DownloadingTask?.IsCompleted ?? true)
						await Task.Delay(1000);

					await piperModel.InferPlayback(message);
				});
			}
		}
	}
}
