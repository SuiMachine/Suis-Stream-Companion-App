using Newtonsoft.Json;
using SSC.Chat;
using SSC.Extensions;
using SuiBot_TwitchSocket;
using SuiBot_TwitchSocket.API.EventSub;
using SuiBotAI.Components.Other.Gemini;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Structs.Gemini.FunctionTypes.Other
{
	public class OpenWeatherCall : FunctionCallSSC
	{
		internal class Geocoding
		{
			public string name;
			public float? lat;
			public float? lon;
			public string country;
			public string state;
		}

		[DebuggerDisplay(nameof(Weather) + " at {dt}")]
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

			public long dt;
			public Weather_Type[] weather;
			public Main_Weather main;
			public Wind_Weather wind;
			public Cloud_Weather clouds;
			public float visibility;
			public DateTime? dt_txt;
			public long? timezone;

			public string GetDescription(bool metric, long timezone)
			{
				StringBuilder sb = new StringBuilder();
				if (dt_txt == null)
					dt_txt = dt.FromUnixTime();

				//TimeZoneInfo easternZone = TimeZoneInfo.
				var offset = TimeSpan.FromSeconds(timezone);
				dt_txt += offset;

				var culture = CultureInfo.GetCultureInfo("en-US");


				sb.AppendLine($"On {dt_txt.Value.ToString(culture)} (local time) is going to be:");

				foreach (var weatherType in weather)
					sb.AppendLine($"- {weatherType.main} ({weatherType.description})");
				sb.AppendLine();

				if (metric)
					sb.AppendLine($"The temperature {main.temp.ToString(culture)}°C (min. {main.temp_min.ToString(culture)}°C, max. {main.temp_max.ToString(culture)}°C), but feels like {main.feels_like.Value.ToString(culture)}°C.");
				else
					sb.AppendLine($"The temperature {main.temp.ToString(culture)}°F (min. {main.temp_min.ToString(culture)}°F, max. {main.temp_max.ToString(culture)}°F), but feels like {main.feels_like.Value.ToString(culture)}°F.");

				sb.AppendLine($"Pressure {main.pressure.ToString(culture)} hPa.");
				sb.AppendLine($"Humidity {main.humidity:0} %.");

				sb.AppendLine($"Visibility {visibility:0} meters.");
				sb.AppendLine($"Cloudiness {clouds.all:0} %.");

				return sb.ToString();
			}
		}

		internal class City
		{
			public string id;
			public string name;
			public string country;
			public ulong? population;
			public long timezone;
			public ulong sunrise;
			public ulong sunset;
		}

		internal class WeatherForecast
		{
			public string cod;
			public string message;
			public string cnt;
			public Weather[] list;
			public City city;
		}

		const string BASE_URI = "http://api.openweathermap.org/";
		[FunctionCallParameter(true)]
		public string city;
		[FunctionCallParameter(true)]
		public string country_code;
		[FunctionCallParameter(true)]
		public string units = "metric";
		[FunctionCallParameter(true)]
		public bool is_weather_forecast = false;

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
					return;
				}

				var first = elements[0];
				var culture = CultureInfo.GetCultureInfo("en-US");
				bool useMetric = units == "metric";

				if (is_weather_forecast)
				{
					result = await HttpWebRequestHandlers.PerformGetAsync(BASE_URI, "data/2.5/forecast", $"?lat={first.lat.Value.ToString(culture)}&lon={first.lon.Value.ToString(culture)}&appid={weatherKey}&units={units}", new Dictionary<string, string>());
					if (string.IsNullOrEmpty(result))
					{
						MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, "Failed to obtain weather for specified location", Role.tool);
						return;
					}

					StringBuilder sb = new StringBuilder();
					var data = JsonConvert.DeserializeObject<WeatherForecast>(result);

					foreach (var element in data.list)
					{
						sb.AppendLine(element.GetDescription(useMetric, data.city.timezone));
						sb.AppendLine();
					}

					MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, sb.ToString(), Role.tool);
				}
				else
				{
					result = await HttpWebRequestHandlers.PerformGetAsync(BASE_URI, "data/2.5/weather", $"?lat={first.lat.Value.ToString(culture)}&lon={first.lon.Value.ToString(culture)}&appid={weatherKey}&units={units}", new Dictionary<string, string>());
					if (string.IsNullOrEmpty(result))
					{
						MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, "Failed to obtain weather for specified location", Role.tool);
						return;
					}

					var data = JsonConvert.DeserializeObject<Weather>(result);
					MainForm.Instance.AI?.GetSecondaryAnswer(channelInstance, message, content, data.GetDescription(useMetric, data.timezone.HasValue ? data.timezone.Value : 0), Role.tool);
				}
			});
		}

		public override string FunctionName() => "weather";

		public override string FunctionDescription() => "Gets current weather for given city. Can request a weather forecast data by setting is_weather_forecast to 1, otherwise it's 0. Units property can be either metric or imperial.";
	}
}
