﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace GameClient.Game
{
	public class ProcessWatcher
	{
		private ICollection<ProcessInfo> ProcessSupplier { get; set; }
		private IEnumerable<Game> GamesSource { get; }
		private Game gameToWatch;
		protected Delayer Delayer;

		public ProcessWatcher(IEnumerable<Game> gamesSource)
		{
			GamesSource = gamesSource;
			Delayer = new Delayer();
		}

		// ReSharper disable once FunctionNeverReturns
		public async Task WatchForRunningGameAsync(int delayInSeconds)
		{
			var started = false;
			var delay = delayInSeconds * 1000;
			while(true)
			{
				ProcessSupplier = GetRunningProcesses();
				var game = GameEntityForRunningProcess;
				if(!started && game.IsRunning(ProcessSupplier))
				{
					gameToWatch = game;
					Start?.Invoke(gameToWatch);
					delay = Math.Max(60000, delayInSeconds * 1000);
					started = true;
				}
				if(game.IsRunning(ProcessSupplier))
				{
					Running?.Invoke(gameToWatch);
					gameToWatch.AddPlaytime(1);
				}
				if(started && !game.IsRunning(ProcessSupplier))
				{
					Exit?.Invoke(gameToWatch);
					delay = delayInSeconds * 1000;
					gameToWatch = game;
					started = false;
				}
				await Delayer.Delay(delay);
			}
		}

		private Game GameEntityForRunningProcess => GamesSource.FirstOrDefault(game => game.IsRunning(ProcessSupplier)) ??
		                                            new NoRunningGame();

		protected virtual List<ProcessInfo> GetRunningProcesses()
		{
			var mngmtClass = new ManagementClass("Win32_Process");
			return mngmtClass.GetInstances()
				.Cast<ManagementBaseObject>()
				.Select(o => new ProcessInfo(o["Name"].ToString(), o["CommandLine"]?.ToString())).ToList();
		}

		public event Action<Game> Start;
		public event Action<Game> Running;
		public event Action<Game> Exit;
	}
}