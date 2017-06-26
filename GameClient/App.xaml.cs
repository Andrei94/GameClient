using System.Windows;
using GameClient.Game;

namespace GameClient
{
	public partial class App
	{
		private GamesList mainViewModel;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			mainViewModel = new GamesList();
			mainViewModel.Show();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);
			mainViewModel.Close();
		}
	}
}
