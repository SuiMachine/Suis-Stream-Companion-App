using System;
using System.Xml.Serialization;

namespace SSC.DataStorage.Videos
{
	[Serializable]
	public class OBS_VideoReward : ICloneable
	{
		[XmlAttribute]
		public string RewardName = "";
		[XmlAttribute]
		public string Description = "";
		[XmlAttribute]
		public int Cooldown = 0;
		[XmlArrayItem]
		public string[] Tags = new string[0];
		[XmlArrayItem]
		public string[] Files = new string[0];


		public string GetFile(Random rng)
		{
			if (Files.Length > 1)
			{
				return Files[rng.Next(0, Files.Length)];
			}
			return Files[0];
		}

		public bool GetIsProperEntry() { return RewardName != null && RewardName != "" && Files != null && Files.Length > 0; }

		public object Clone() => CreateCopy();

		public OBS_VideoReward CreateCopy()
		{
			var obj = new OBS_VideoReward();
			obj.Tags = new string[Tags.Length];
			for (int i = 0; i < Tags.Length; i++)
			{
				obj.Tags[i] = Tags[i];
			}
			obj.Files = new string[Files.Length];
			for (int i = 0; i < Files.Length; i++)
			{
				obj.Files[i] = Files[i];
			}
			obj.RewardName = RewardName;
			obj.Cooldown = Cooldown;
			obj.Description = Description;

			return obj;
		}
	}
}
