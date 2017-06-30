using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameClient.MostPlayed;
using GameClient.Processes;
using WPFCommonUI;

namespace GameClient.MainProgram
{
    public class GameList : ViewModelBase<IMainView>
    {
        private RunningGameInfo runningGame;
        private bool isGameRunning;
        private int playtime;
        private IEnumerable<Game.Game> games;
        private readonly GameDao gameSrc;

        public RunningGameInfo RunningGame
        {
            get => runningGame;
            set
            {
                runningGame = value;
                RaisePropertyChanged(nameof(RunningGame));
            }
        }

        public IEnumerable<Game.Game> Games
        {
            get => games;
            set
            {
                games = value;
                RaisePropertyChanged(nameof(Games));
            }
        }

        public bool IsGameRunning
        {
            get => isGameRunning;
            set
            {
                isGameRunning = value;
                RaisePropertyChanged(nameof(IsGameRunning));
            }
        }

        public RelayCommand SortCommand { get; }

        public GameList(GameDao src) : base(new MainWindow())
        {
            gameSrc = src;
            Games = src.Games;

            SortCommand = new RelayCommand(Sort);

            var watcher = new ProcessWatcher(src.Games);
            watcher.Start += game => Task.Run(() => OnStart(game));
            watcher.Running += game => Task.Run(() => OnRunning(game));
            watcher.Exit += game => Task.Run(() => OnExit(game));
            Task.Run(async () => await watcher.WatchForRunningGameAsync(5));
        }

        private void Sort(object obj)
        {
            new MostPlayedGames(Games.OrderByDescending(g => g.Playtime)).Show();
        }

        private void OnStart(Game.Game game)
        {
            RunningGame = new RunningGameInfo(game.Name, playtime);
            IsGameRunning = true;
        }

        private void OnRunning(Game.Game game)
        {
            Games = gameSrc.Games;
            playtime++;
            game.AddPlaytime(1);
            RunningGame = new RunningGameInfo(game.Name, playtime);
            gameSrc.UpdatePlaytime(game);
        }

        private void OnExit(Game.Game game)
        {
            gameSrc.UpdatePlaytime(game);
            Games = gameSrc.Games;
            RunningGame = null;
            IsGameRunning = false;
            playtime = 0;
        }

        public void Show()
        {
            View.Show();
        }

        public void Close()
        {
            View.Close();
        }
    }
}