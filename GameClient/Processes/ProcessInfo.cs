namespace GameClient.Processes
{
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
}