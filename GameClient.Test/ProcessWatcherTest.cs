using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameClient.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Test
{
	[TestClass]
	public class ProcessWatcherTest
	{
		private List<Game.Game> games;
		private ProcessWatcherTransitions watcher;

		[TestInitialize]
		public void Setup()
		{
			games = new List<Game.Game>
			{
				new Game.Game
				{
					Name = "Skyrim",
					ProcessName = "skyrim.exe"
				},
				new Game.Game
				{
					Name = "Warfront",
					ProcessName = "warfront.exe"
				}
			};
			watcher = new ProcessWatcherTransitions(games);
		}

		[TestMethod]
		public void WatchProcessesList()
		{
			watcher.Start += game => OnProcessChanged(game, ProcessWatcherTransitions.GameState.None,
				ProcessWatcherTransitions.GameState.Started);
			watcher.Running += game => OnProcessChanged(game, ProcessWatcherTransitions.GameState.Started,
				ProcessWatcherTransitions.GameState.Running);
			watcher.Exit += game => OnProcessChanged(game, ProcessWatcherTransitions.GameState.Running,
				ProcessWatcherTransitions.GameState.Exited);
			watcher.WatchForRunningGameAsync(1).Wait(1);
			Assert.AreEqual(ProcessWatcherTransitions.GameState.Exited, watcher.State);
		}

		// ReSharper disable once UnusedParameter.Local
		private void OnProcessChanged(Game.Game game, ProcessWatcherTransitions.GameState oldState,
			ProcessWatcherTransitions.GameState newState)
		{
			Assert.IsNotNull(game);
			Assert.AreEqual(oldState, watcher.State);
			watcher.State = newState;
		}

		private class ProcessWatcherTransitions : ProcessWatcher
		{
			internal enum GameState
			{
				None,
				Started,
				Running,
				Exited
			}

			internal GameState State = GameState.None;

			public ProcessWatcherTransitions(IEnumerable<Game.Game> gamesSource) : base(gamesSource)
			{
				Delayer = new DelayerImmediateReturn();
			}

			protected override List<ProcessInfo> GetRunningProcesses()
			{
				switch(State)
				{
					case GameState.None:
						return new List<ProcessInfo>
						{
							new ProcessInfo("skyrim.exe", string.Empty),
							new ProcessInfo("jdksahjkdhjaks", string.Empty),
							new ProcessInfo("hoi5.exe", string.Empty)
						};
					case GameState.Started:
						return new List<ProcessInfo>
						{
							new ProcessInfo("skyrim.exe", string.Empty),
							new ProcessInfo("jdksahjkdhjaks", string.Empty),
							new ProcessInfo("hoi5.exe", string.Empty)
						};
					case GameState.Running:
						return new List<ProcessInfo>
						{
							new ProcessInfo("jdksahjkdhjaks", string.Empty),
							new ProcessInfo("hoi5.exe", string.Empty)
						};
					case GameState.Exited:
						return new List<ProcessInfo>();
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}
	}

	internal class DelayerImmediateReturn : Delayer
	{
		public override Task Delay(int miliseconds)
		{
			return Task.Run(() => true);
		}
	}
}