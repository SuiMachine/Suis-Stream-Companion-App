using System;
using System.Collections.Generic;
using System.IO;

namespace SSC
{
	public class Notes
	{
		private static string DefaultNotesPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "Notes", "Main.SSCNote");


		private static Notes m_Instance;
		public static Notes GetInstance()
		{
			if (m_Instance == null)
				m_Instance = new Notes();
			return m_Instance;
		}

		public Notes()
		{
			var config = AIConfig.GetInstance();
			if(config.NotesFile  == null || !File.Exists(config.NotesFile))
				config.NotesFile = DefaultNotesPath();

			CurrentFile = config.NotesFile;
			CurrentNotes = XML_Utils.Load(CurrentFile, new List<string>());
		}

		public string CurrentFile = null;
		public List<string> CurrentNotes = new();
	}
}
