using System;
using System.Globalization;
using System.Windows.Data;

namespace GameClient.MainProgram
{
	public class PlaytimeConverter : IValueConverter
	{
		private const int MinutesPerHour = 60;
		private const int MinutesPerDay = 1440;
		private const string DefaultValue = "0";

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value == null) return DefaultValue;
			int playtime;
			return !int.TryParse(value.ToString(), out playtime)
				? DefaultValue
				: ConvertPlaytime(playtime);
		}

		public static string ConvertPlaytime(int playtimeInMinutes)
		{
			var minutes = playtimeInMinutes % MinutesPerHour;
			var hours = playtimeInMinutes % MinutesPerDay / MinutesPerHour;
			var days = playtimeInMinutes / MinutesPerDay;
			return ((days == 0 ? string.Empty : $"{days}d ") +
			        (hours == 0 ? string.Empty : $"{hours}h ") +
			        (minutes == 0 ? string.Empty : $"{minutes}m")).Trim();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}