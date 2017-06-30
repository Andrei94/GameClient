using System.Collections.Generic;
using GameClient.Game;
using MongoDB.Driver;

namespace GameClient.MainProgram
{
	public class GameDao
	{
		public List<Game.Game> Games { get; private set; }
		private readonly IMongoCollection<GameMongo> mongoCollection;

		public GameDao(string dbName)
		{
			var client = new MongoClient("mongodb://localhost:27017");
			var db = client.GetDatabase(dbName);
			mongoCollection = db.GetCollection<GameMongo>("Games");
			SyncContents();
		}

		public void UpdatePlaytime(Game.Game game)
		{
			var matchProcessName = Builders<GameMongo>.Filter.Eq(nameof(game.ProcessName), game.ProcessName);
			var matchName = Builders<GameMongo>.Filter.Eq(nameof(game.Name), game.Name);
			var matchArgument = Builders<GameMongo>.Filter.Eq(nameof(game.Argument), game.Argument);
			var updateDefinition = Builders<GameMongo>.Update.Set(nameof(game.Playtime), game.Playtime);
			mongoCollection.UpdateOne(Builders<GameMongo>.Filter.And(matchProcessName, matchName, matchArgument),
				updateDefinition);
			SyncContents();
		}

		private void SyncContents()
		{
			var cursor = mongoCollection.FindSync(x => true);
			Games = new List<Game.Game>();
			while(cursor.MoveNext())
				Games.AddRange(cursor.Current);
		}
	}
}
