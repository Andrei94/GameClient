using System.Collections.Generic;
using WPFCommonUI;

namespace GameClient.MostPlayed
{
	internal class MostPlayedGames : ViewModelBase<IMainView>
	{
		public IEnumerable<Game.Game> Games { get; }

		public MostPlayedGames(IEnumerable<Game.Game> games) : base(new MostPlayed())
		{
			Games = games;
		}

		public void Show()
		{
			View.Show();
		}
	}
}
