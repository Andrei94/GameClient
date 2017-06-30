using System;
using System.Globalization;
using System.Windows.Data;

namespace GameClient.MainProgram
{
	public class RunningGameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is RunningGameInfo)
			{
				var runningGame = (RunningGameInfo) value;
				return string.IsNullOrEmpty(runningGame.Playtime)
					? $"Playing {runningGame.Name}"
					: $"Playing {runningGame.Name} for {runningGame.Playtime}";
			}
			return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}