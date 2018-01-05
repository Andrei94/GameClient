using System.Collections.Generic;
using System.Linq;
using GameClient.Processes;

namespace GameClient.Game
{
	public class Game
	{
		public virtual string Name { get; set; }

		public virtual string ProcessName { get; set; }

		public virtual int Playtime { get; set; }

		public virtual string Argument { get; set; }

		public virtual bool IsRunning(IEnumerable<ProcessInfo> processNames)
		{
			return processNames.Any(p => p.Equals(new ProcessInfo(ProcessName, Argument)));
		}

		public virtual void AddPlaytime(int minutes)
		{
			Playtime += minutes;
		}

	    public static int ConvertToMinutes(int days, int hours, int minutes)
	    {
	        const int minutesPerHour = 60;
	        const int hoursPerDay = 24;
	        return minutes + minutesPerHour * hours + hoursPerDay * minutesPerHour * days;
	    }
    }

	public class NoRunningGame : Game
	{
		public override bool IsRunning(IEnumerable<ProcessInfo> processNames)
		{
			return false;
		}

		public override void AddPlaytime(int minutes)
		{
		}
	}
}