using System;
using System.Collections.Generic;
using System.Linq;

namespace GameClient.Game
{
	public class Game
	{
		public virtual string Name { get; set; }

		public virtual string ProcessName { get; set; }

		public virtual int Playtime { get; set; }

		public virtual string Argument { get; set; } = "";

//		public virtual bool IsRunning(IEnumerable<string> processNames) => Argument == null
//			? processNames.Any(name => name.Contains(ProcessName))
//			: processNames.Any(name => name.Contains(ProcessName) && name.Contains(Argument));

//		public virtual bool IsRunning(IEnumerable<ProcessInfo> processNames) => processNames.Any(name => name.Contains(ProcessName) && name.Contains(Argument ?? string.Empty));
		public virtual bool IsRunning(IEnumerable<ProcessInfo> processNames)
		{
			return processNames.Any(p => p.Equals(new ProcessInfo(ProcessName, Argument)));
		}

		public virtual void AddPlaytime(int minutes)
		{
			Playtime += minutes;
		}
	}

	public class ProcessInfo
	{
		public ProcessInfo(string processName, string argument)
		{
			Name = processName ?? string.Empty;
			Argument = argument ?? string.Empty;
		}

		public string Name { get; set; }
		public string Argument { get; set; }

		public override bool Equals(object obj)
		{
			var other = (ProcessInfo) obj;
			return other != null && Name.Equals(other.Name) && Argument.Contains(other.Argument);
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