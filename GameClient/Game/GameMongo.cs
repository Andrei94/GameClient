using MongoDB.Bson.Serialization.Attributes;

namespace GameClient.Game
{
	[BsonIgnoreExtraElements]
	public class GameMongo : Game
	{
		[BsonElement("name")]
		public override string Name { get; set; }
		[BsonElement("processName")]
		public override string ProcessName { get; set; }
		[BsonElement("playtime")]
		public override int Playtime { get; set; }
		[BsonElement("argument")]
		public override string Argument { get; set; }
	}
}