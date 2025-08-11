using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Whisper.net;
using Whisper.net.Ggml;
using Whisper.net.Logger;

namespace SSC
{
	public class SpeechRecognition : IDisposable
	{
		public bool Disposed { get; private set; } = false;
		private Task Initialization;
		private WhisperProcessor m_Processor;
		private WhisperFactory m_Factory;
		private IDisposable m_Logger;

		private static SpeechRecognition m_Instance;
		public static SpeechRecognition GetInstance()
		{
			if(m_Instance == null)
			{
				m_Instance = new SpeechRecognition();
			}
			return m_Instance;
		}

		private SpeechRecognition()
		{
			Initialization = Task.Run(Initialize);
		}

		public async Task Initialize()
		{
			// We declare three variables which we will use later, ggmlType, modelFileName and inputFileName
			var ggmlType = GgmlType.Base;
			var modelFileName = "ggml-base.bin";

			// This section detects whether the "ggml-base.bin" file exists in our project disk. If it doesn't, it downloads it from the internet
			if (!File.Exists(modelFileName))
			{
				await DownloadModel(modelFileName, ggmlType);
			}

			// Optional logging from the native library
			m_Logger = LogProvider.AddConsoleLogging(WhisperLogLevel.Debug);

			// This section creates the whisperFactory object which is used to create the processor object.
			m_Factory = WhisperFactory.FromPath("ggml-base.bin", new WhisperFactoryOptions()
			{
				UseGpu = false
			});

			// This section creates the processor object which is used to process the audio file, it uses language `auto` to detect the language of the audio file.
			// It also sets the segment event handler, which is called every time a new segment is detected.
			m_Processor = m_Factory.CreateBuilder()
				.WithLanguage("auto")
				.WithSegmentEventHandler((segment) =>
				{
					MainForm.Instance?.ProcessSpeechInput(segment);
					// Do whetever you want with your segment here.
					Debug.WriteLine($"{segment.Start}->{segment.End}: {segment.Text}");
				})
				.Build();
		}

		public async Task<string> RecognizeSpeech(Stream contents)
		{
			while(true)
			{
				while(!Initialization.IsCompleted)
				{
					if (Initialization.IsCanceled)
						return null;
				}

				contents.Position = 0;
				StringBuilder sb = new StringBuilder();

				await foreach(var result in m_Processor.ProcessAsync(contents))
				{
					Debug.WriteLine($"{result.Start}->{result.End}: {result.Text}");
					sb.AppendLine(result.Text);
				}
				return sb.ToString();
			}
		}


		private async Task DownloadModel(string fileName, GgmlType ggmlType)
		{
			Debug.WriteLine($"Downloading Model {fileName}");
			using var modelStream = await WhisperGgmlDownloader.Default.GetGgmlModelAsync(ggmlType);
			using var fileWriter = File.OpenWrite(fileName);
			await modelStream.CopyToAsync(fileWriter);
		}

		public void Dispose()
		{
			m_Processor?.Dispose();
			m_Factory?.Dispose();
			m_Logger?.Dispose();
			this.Disposed = true;
		}
	}
}
