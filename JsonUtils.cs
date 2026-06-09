using Newtonsoft.Json;
using System;
using System.IO;

namespace SSC
{
	public static class JsonUtils
	{
		public static T Load<T>(string filePath, T defaultVal)
		{
			string DirectoryPath = Directory.GetParent(filePath).FullName;


			if (!Directory.Exists(DirectoryPath))
			{
				Directory.CreateDirectory(DirectoryPath);
				return defaultVal;
			}

			if (!File.Exists(filePath))
				return defaultVal;

			var text = File.ReadAllText(filePath);
			try
			{
				T result = JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.Auto,
				});
				return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading JSON from {filePath}: {ex.Message}");
				return defaultVal;
			}
		}

		public static void Save<T>(string filePath, T objectToSave, Formatting formatting = Formatting.Indented)
		{
			string DirectoryPath = Directory.GetParent(filePath).FullName;

			if (!Directory.Exists(DirectoryPath))
				Directory.CreateDirectory(DirectoryPath);

			var textResult = JsonConvert.SerializeObject(objectToSave, new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Auto,
				Formatting = formatting
			});
			File.WriteAllText(filePath, textResult);
		}
	}
}
