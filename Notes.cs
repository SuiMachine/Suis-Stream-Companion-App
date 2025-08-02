using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SSC
{
	public class Notes
	{
		internal static string DefaultNotesPath() => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SSC", "Notes", "Main.SSCNote");


		private static Notes m_Instance;
		public static Notes GetInstance()
		{
			if (m_Instance == null)
			{
				m_Instance = new Notes();
			}
			return m_Instance;
		}

		public void Open(string file)
		{
			if (!File.Exists(file))
			{
				CurrentFile = file;
				CurrentNotes = XML_Utils.Load(CurrentFile, new List<NotesEntity>());
				PrivateSettings.GetInstance().LastNotesFile = CurrentFile;
			}
		}

		internal void Save()
		{
			XML_Utils.Save(this.CurrentFile, CurrentNotes);
		}

		internal void SaveAs(string fileName)
		{
			XML_Utils.Save(fileName, CurrentNotes);
			Open(fileName);
		}

		public Notes()
		{
			var config = PrivateSettings.GetInstance();
			if(config.LastNotesFile == null || !File.Exists(config.LastNotesFile))
				config.LastNotesFile = DefaultNotesPath();

			CurrentFile = config.LastNotesFile;
			CurrentNotes = XML_Utils.Load(CurrentFile, new List<NotesEntity>());
		}

		public class NotesEntity
		{
			[XmlAttribute] public bool Completed { get; set; } = false;
			[XmlText] public string Content { get; set; } = "";
		}

		[XmlIgnore] public string CurrentFile = null;
		public List<NotesEntity> CurrentNotes = new();
	}
}
