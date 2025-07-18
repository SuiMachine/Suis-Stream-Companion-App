﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SSC.SoundStorage
{
	class SoundStorageXML
	{
		public static List<SoundEntry> LoadSoundBase(string XmlPath)
		{
			List<SoundEntry> entries;
			if (!File.Exists(XmlPath))
			{
				entries = new List<SoundEntry>();
				SaveSoundBase(XmlPath, entries);
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SoundEntry>));
				FileStream fs = new FileStream(XmlPath, FileMode.Open);
				entries = (List<SoundEntry>)xmlSerializer.Deserialize(fs);
				fs.Dispose();
			}
			return entries;
		}

		public static void SaveSoundBase(string XmlPath, List<SoundEntry> entries)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SoundEntry>));
			var folder = Directory.GetParent(XmlPath).FullName;
			if (!Directory.Exists(folder))
				Directory.CreateDirectory(folder);

			FileStream fs = new FileStream(XmlPath, FileMode.Create);
			xmlSerializer.Serialize(fs, entries);
			fs.Dispose();
		}
	}
}
