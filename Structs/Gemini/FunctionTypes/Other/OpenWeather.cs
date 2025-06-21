using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SSC.Chat;
using SuiBot_TwitchSocket;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using SuiBotAI.Components.Other.Gemini.FunctionTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Structs.Gemini.FunctionTypes.Other
{
	[Serializable]
	public class OpenWeatherCallProperty : GeminiProperty
	{
		public Parameter_String city = new Parameter_String();
		public Parameter_String country_code = new Parameter_String();
		public Parameter_String units = new Parameter_String();

		public override List<string> GetRequiredFieldsNames() => new List<string>()
		{
			nameof(city),
		};
	}

	public class OpenWeather : FunctionCall
	{
		internal class Geocoding
		{
			public string name;
			public float? lat;
			public float? lon;
			public string country;
			public string state;
		}

		internal class Weather
		{
			public class Weather_Type
			{
				public int id;
				public string main;
				public string description;
			}

			public class Main_Weather
			{
				public float temp;
				public float? feels_like;
				public float temp_min;
				public float temp_max;
				public float pressure;
				public float humidity;
				public float sea_level;
				public float grnd_level;
			}

			public class Wind_Weather
			{
				public float speed;
				public float deg;
				public float gust;
			}

			public class Cloud_Weather
			{
				public float all;
			}

			public Weather_Type[] weather;
			public Main_Weather main;
			public Wind_Weather wind;
			public Cloud_Weather clouds;
			public float visibility;

			public string GetDescription(bool metric)
			{
				StringBuilder sb = new StringBuilder();
				sb.AppendLine("Current weather described as: ");
				foreach(var weatherType in weather)
					sb.AppendLine($"- {weatherType.main} ({weatherType.description})");
				sb.AppendLine();

				if (metric)
					sb.AppendLine($"The temperature is {main.temp:0.0}°C (min. {main.temp_min:0.0}°C, max. {main.temp_max:0.0}°C), but feels like {main.feels_like:0.0}°C.");
				else
					sb.AppendLine($"The temperature is {main.temp:0.0}°F (min. {main.temp_min:0.0}°F, max. {main.temp_max:0.0}°F), but feels like {main.feels_like:0.0}°F.");

				sb.AppendLine($"Pressure {main.pressure:0.0} hPa.");
				sb.AppendLine($"Humidity {main.humidity:0} %.");

				sb.AppendLine($"Visibility {visibility:0} meters.");
				sb.AppendLine($"Cloudiness {clouds.all:0} %.");


				return sb.ToString();
			}
		}

		const string BASE_URI = "http://api.openweathermap.org/";
		public string city;
		public string country_code;
		public string units = "metric";

		public override void Perform(ChannelInstance channelInstance, ES_ChatMessage message, GeminiContent content)
		{
			var weatherKey = (string)AIConfig.GetInstance().WeatherAPIKey;
			if (string.IsNullOrEmpty(weatherKey))
				return;

			Task.Run(async () =>
			{
				string finalCity = city;
				if (!string.IsNullOrEmpty(country_code))
					finalCity = $"{city},{country_code}";

				var result = await HttpWebRequestHandlers.PerformGetAsync(BASE_URI, "geo/1.0/direct", $"?q={finalCity}&appid={weatherKey}", new Dictionary<string, string>());
				if (string.IsNullOrEmpty(result))
				{
					MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, "Couldn't find geocoding for provided location.", Role.tool);
					return;
				}

				var elements = JsonConvert.DeserializeObject<Geocoding[]>(result);
				if (elements.Length == 0)
				{
					MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, "Couldn't find geocoding for provided location.", Role.tool);
					return;
				}

				var first = elements[0];
				var culture = CultureInfo.GetCultureInfo("en-US");

				result = await HttpWebRequestHandlers.PerformGetAsync(BASE_URI, "data/2.5/weather", $"?lat={first.lat.Value.ToString(culture)}&lon={first.lon.Value.ToString(culture)}&appid={weatherKey}&units={units}", new Dictionary<string, string>());
				if (string.IsNullOrEmpty(result))
				{
					MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, "Failed to obtain weather for specified location", Role.tool);
					return;
				}

				var data = JsonConvert.DeserializeObject<Weather>(result);
				MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, data.GetDescription(units == "metric"), Role.tool);
			});

		}
	}
}
