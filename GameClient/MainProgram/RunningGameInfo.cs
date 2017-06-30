namespace GameClient.MainProgram
{
	public class RunningGameInfo
	{
		public string Name { get; }
		public string Playtime { get; }

		public RunningGameInfo(string name, int playtimeInMinutes = 0)
		{
			Name = name;
			Playtime = PlaytimeConverter.ConvertPlaytime(playtimeInMinutes);
		}
	}
}
