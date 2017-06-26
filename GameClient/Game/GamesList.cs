using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WPFCommonUI;

namespace GameClient.Game
{
	public class GamesList : ViewModelBase<IMainView>
	{
		private string runningGame;

		public string RunningGame
		{
			get => runningGame;
			set
			{
				runningGame = value;
				RaisePropertyChanged("RunningGame");
			}
		}

		public List<Game> Games { get; }

		public GamesList() : base(new MainWindow())
		{
			var client = new MongoClient("mongodb://localhost:27017");
			var db = client.GetDatabase("Games");
			var mongoCollection = db.GetCollection<GameMongo>("Games");
			var cursor = mongoCollection.FindSync(x => true);
			Games = new List<Game>();
			while(cursor.MoveNext())
				Games.AddRange(cursor.Current);

			var watcher = new ProcessWatcher(Games);
			watcher.Start += game => RunningGame = game.Name;
			watcher.Exit += game => RunningGame = string.Empty;
			Task.Run(async () => await watcher.WatchForRunningGameAsync(1));
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