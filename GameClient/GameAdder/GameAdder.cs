using GameClient.MainProgram;
using WPFCommonUI;

namespace GameClient.GameAdder
{
    public class GameAdder : ViewModelBase<IDialogView>
    {
        private string gameName;
        public string GameName
        {
            get => gameName;
            set
            {
                gameName = value;
                RaisePropertyChanged(nameof(GameName));
            }
        }

        private string processName;
        public string ProcessName
        {
            get => processName;
            set
            {
                processName = value;
                RaisePropertyChanged(nameof(ProcessName));
            }
        }

        private string argument;
        public string Argument
        {
            get => argument;
            set
            {
                argument = value;
                RaisePropertyChanged(nameof(Argument));
            }
        }

        private int days;
        public int Days
        {
            get => days;
            set
            {
                days = value;
                RaisePropertyChanged(nameof(Days));
            }
        }

        private int hours;
        public int Hours
        {
            get => hours;
            set
            {
                hours = value;
                RaisePropertyChanged(nameof(Hours));
            }
        }

        private int minutes;
        public int Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                RaisePropertyChanged(nameof(Minutes));
            }
        }

        private readonly Dao src;
        public RelayCommand AddGameCommand { get; }
        public RelayCommand CloseWindowCommand { get; }

        public GameAdder(Dao gameSrc) : base(new AddGameWindow())
        {
            src = gameSrc;
            AddGameCommand = new RelayCommand(AddGame, AreFieldsFilled);
            CloseWindowCommand = new RelayCommand(Close);
        }

        private void AddGame(object obj)
        {
            src.Insert(new Game.Game
            {
                Name = gameName,
                ProcessName = processName,
                Argument = argument,
                Playtime = Game.Game.ConvertToMinutes(days, hours, minutes)
            });
            Close(obj);
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(gameName) &&
                   !string.IsNullOrWhiteSpace(processName) &&
                   days >= 0 &&
                   hours >= 0 && hours < 24 &&
                   minutes >= 0 && minutes < 60;
        }

        private void Close(object o)
        {
            View.Close();
        }

        public void ShowDialog()
        {
            View.ShowDialog();
        }
    }
}