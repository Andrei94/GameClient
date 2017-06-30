using System;
using System.Diagnostics;
using System.Windows;
using GameClient.MainProgram;

namespace GameClient
{
    public partial class App
    {
        private GameList mainViewModel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mongoDbPath = Environment.GetEnvironmentVariable("MongoDB");
            if(mongoDbPath == null)
            {
                MessageBox.Show("MongoDB environment variable not found! The program will terminate");
                return;
            }
            Process.Start(new ProcessStartInfo("mongod.exe")
            {
                WorkingDirectory = mongoDbPath,
                WindowStyle = ProcessWindowStyle.Hidden
            });
            mainViewModel = new GameList(new GameDao("Games"));
            mainViewModel.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            mainViewModel.Close();
        }
    }
}