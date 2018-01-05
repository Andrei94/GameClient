using MongoDB.Bson.Serialization.Attributes;

namespace GameClient.Game
{
	[BsonIgnoreExtraElements]
	public class GameMongo : Game
	{
	    public GameMongo()
	    {
	    }

	    public GameMongo(Game game)
	    {
	        Name = game.Name;
	        ProcessName = game.ProcessName;
	        Playtime = game.Playtime;
	        Argument = game.Argument;
	    }

	    public override string Name { get; set; }
		public override string ProcessName { get; set; }
		public override int Playtime { get; set; }
		public override string Argument { get; set; }
	}
}