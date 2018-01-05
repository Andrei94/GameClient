using System.Collections.Generic;

namespace GameClient.MainProgram
{
    public interface Dao
    {
        List<Game.Game> Games { get; }
        void UpdatePlaytime(Game.Game game);
        void Insert(Game.Game game);
    }
}