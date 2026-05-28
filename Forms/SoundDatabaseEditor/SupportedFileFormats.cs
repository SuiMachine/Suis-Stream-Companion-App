using System.IO;
using System.Linq;

namespace SSC.Forms.SoundDatabaseEditor
{
	public static class SupportedVideoFileFormats
	{
		private static string[] arrayOfAcceptableExtensions = new string[] {
			".mp4",
			".mpv",
			".ts",
			".mov",
			".mxf",
			".flv",
			".mkv",
			".avi",
			".gif",
			".webm"
		};

		public static bool IsAcceptableVideoFormat(string filePath)
		{
			var extension = Path.GetExtension(filePath);
			return arrayOfAcceptableExtensions.Contains(extension);
		}

		private static string[] privFilter = new string[] {
			"MP4 Video (*.mp4)|*.mp4",
			"MPEG Video (*.mpv)|*.mpv",
			"MPEG Transport Stream (*.ts)|*.ts",
			"QuickTime Movie (*.mov)|*.mov",
			"MXF Video (*.mxf)|*.mxf",
			"Flash Video (*.flv)|*.flv",
			"Matroska Video (*.mkv)|*.mkv",
			"AVI Video (*.avi)|*.avi",
			"GIF Animation (*.gif)|*.gif",
			"WebM Video (*.webm)|*.webm",
			"Supported video formats|*.mp4;*.mpv;*.ts;*.mov;*.mxf;*.flv;*.mkv;*.avi;*.gif;*.webm"
		};
		public static string Filter = string.Join("|", privFilter);
		public static int LastIndex = privFilter.Length;
	}
}
