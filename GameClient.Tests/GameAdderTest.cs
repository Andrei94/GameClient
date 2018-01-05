using System.Collections.Generic;
using GameClient.MainProgram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameClient.Tests
{
    [TestClass]
    public class GameAdderTest
    {
        private GameDaoDummy gameDao;

        [TestInitialize]
        public void SetUp()
        {
            gameDao = new GameDaoDummy();
        }

        [TestMethod]
        public void CanAddGame()
        {
            Assert.IsTrue(CreateGameAdder("some game", "some game").AddGameCommand.CanExecute(null));
            Assert.IsTrue(CreateGameAdder("some game", "some game", 1, 20, 20).AddGameCommand.CanExecute(null));
        }

        [TestMethod]
        public void DontAddGameWithInvalidPlaytime()
        {
            Assert.IsFalse(CreateGameAdder("some game", "some game", -1, -1, -1).AddGameCommand.CanExecute(null));
            Assert.IsFalse(CreateGameAdder("some game", "some game", 0, -1, -1).AddGameCommand.CanExecute(null));
            Assert.IsFalse(CreateGameAdder("some game", "some game", 0, 25, -1).AddGameCommand.CanExecute(null));
            Assert.IsFalse(CreateGameAdder("some game", "some game", 0, 20, -1).AddGameCommand.CanExecute(null));
            Assert.IsFalse(CreateGameAdder("some game", "some game", 0, 20, 61).AddGameCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddGame()
        {
            var gameAdder = CreateGameAdder("some game", "some game");
            gameAdder.AddGameCommand.Execute(null);
            Assert.IsTrue(gameDao.IsInserted);
        }

        private GameAdder.GameAdder CreateGameAdder(string gameName, string procName, int days = 0, int hours = 0, int minutes = 0)
        {
            return new GameAdder.GameAdder(gameDao)
            {
                GameName = gameName,
                ProcessName = procName,
                Days = days,
                Hours = hours,
                Minutes = minutes
            };
        }

        private class GameDaoDummy : Dao
        {
            public bool IsInserted { get; set; }

            public List<Game.Game> Games { get; }

            public void UpdatePlaytime(Game.Game game)
            {
                throw new System.NotImplementedException();
            }

            public void Insert(Game.Game game)
            {
                IsInserted = true;
            }
        }
    }
}
