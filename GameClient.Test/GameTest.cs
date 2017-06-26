using System.Collections.Generic;
using GameClient.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Test
{
	[TestClass]
	public class GameTest
	{
		[TestMethod]
		public void IsGameRunning()
		{
			var hoi4 = new Game.Game {ProcessName = "hoi4.exe"};
			Assert.IsTrue(hoi4.IsRunning(new List<ProcessInfo>
			{
				new ProcessInfo("skyrim.exe", string.Empty),
				new ProcessInfo("hoi4.exe", string.Empty)
			}));
		}

		[TestMethod]
		public void IsGameRunningWithArguments()
		{
			var bf1942 = new Game.Game {ProcessName = "bf1942.exe", Argument = "Xpack"};
			Assert.IsTrue(bf1942.IsRunning(new List<ProcessInfo>
			{
				new ProcessInfo("skyrim.exe", string.Empty),
				new ProcessInfo("hoi4.exe", string.Empty),
				new ProcessInfo("bf1942.exe", string.Empty),
				new ProcessInfo("bf1942.exe", "Xpack")
			}));
		}

		[TestMethod]
		public void AddOneMinutePlaytime()
		{
			var game = new Game.Game();
			game.AddPlaytime(1);
			Assert.AreEqual(1, game.Playtime);
		}
	}
}