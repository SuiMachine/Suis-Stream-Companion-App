using System;

namespace SSC.Extensions
{
	static class DateTimeExtensions
	{
		public static DateTime ToDateTimeSafe(this string Text)
		{
			if (string.IsNullOrEmpty(Text))
			{
				return DateTime.UtcNow;
			}
			else
			{
				if (DateTime.TryParse(Text, out DateTime result))
				{
					return result;
				}
				else
				{
					return DateTime.MinValue;
				}
			}
		}

		public static long ToUnixTime(this DateTime dateTime)
		{
			//This is a bit idiotic... ugh
			var result = ((DateTimeOffset)dateTime.ToLocalTime()).ToUnixTimeSeconds();
			return result;
		}

		public static DateTime FromUnixTime(this long dateTime)
		{
			//This is a bit idiotic... ugh
			var dtOffset = DateTimeOffset.FromUnixTimeSeconds(dateTime);
			var result = dtOffset.UtcDateTime;
			return result;
		}
	}
}
