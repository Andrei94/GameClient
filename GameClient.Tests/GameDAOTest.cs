using System.Configuration;
using GameClient.Game;
using GameClient.MainProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;

namespace GameClient.Tests
{
    [TestClass]
    public class GameDaoTest
    {
        private readonly IMongoCollection<GameMongo> mongoCollection;
        private readonly GameDao gameDao;

        public GameDaoTest()
        {
            var dbName = ConfigurationManager.AppSettings["DBName"];
            var collectionName = ConfigurationManager.AppSettings["Collection"];
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            mongoCollection = db.GetCollection<GameMongo>(dbName);
            if(mongoCollection == null)
                db.CreateCollection(dbName);
            mongoCollection = db.GetCollection<GameMongo>(collectionName);
            gameDao = new GameDao(connectionString, dbName, collectionName);
        }

        [TestMethod]
        public void AddGameToDb()
        {
            gameDao.Insert(new GameMongo {Name = "Some game", ProcessName = "someProc.exe", Playtime = 20});
            Assert.AreEqual(1, gameDao.Games.Count);
        }

        [TestMethod]
        public void UpdatePlaytime()
        {
            mongoCollection.InsertOne(new GameMongo { Name = "Some game", ProcessName = "someProc.exe", Playtime = 20 });
            gameDao.UpdatePlaytime(new GameMongo { Name = "Some game", ProcessName = "someProc.exe", Playtime = 30 });
            Assert.AreEqual(30, gameDao.Games[0].Playtime);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mongoCollection.DeleteMany(doc => true);
        }
    }
}
