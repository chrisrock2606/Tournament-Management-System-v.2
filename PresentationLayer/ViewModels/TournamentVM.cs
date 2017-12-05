using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Input;
using System.Windows.Data;
using System.Globalization;
using DomainLayer;
using ServiceAccessLayer;


namespace PresentationLayer.ViewModels
{
    class TournamentVM : ModelBase
    {
        #region Properties

        public ObservableCollection<Tournament> TournamentList { get; set; }
        private SaveData SD;
        public ICommand CommandCreateTournament { get; set; }
        public ICommand CommandDeleteTournament { get; set; }
        public ICommand CommandUpdateSelection { get; set; }
        public ICommand CommandCreateRound { get; set; }


        public ObservableCollection<int> ComboboxValues { get; set; }

        private int selectedMaxValue;

        public int SelectedMaxValue
        {
            get { return selectedMaxValue; }
            set
            {
                if (value != selectedMaxValue)
                {
                    selectedMaxValue = value;

                    if (SelectedMinValue > value)
                        SelectedMinValue = value;

                    NotifyPropertyChanged();
                }
            }
        }

        private int selectedMinValue;
        public int SelectedMinValue
        {
            get { return selectedMinValue; }
            set
            {
                if (value != selectedMinValue)
                {
                    selectedMinValue = value;

                    if (SelectedMaxValue < value)
                        SelectedMaxValue = value;

                    NotifyPropertyChanged();
                }
            }
        }


        private string tournamentName;
        public string TournamentName
        {
            get { return tournamentName; }
            set
            {
                if (value != tournamentName)
                {
                    tournamentName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string gameName;
        public string GameName
        {
            get { return gameName; }
            set
            {
                if (value != gameName)
                {
                    gameName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int selectedTournamentItemIndex;
        public int SelectedTournamentItemIndex
        {
            get { return selectedTournamentItemIndex; }
            set
            {
                if (value != selectedTournamentItemIndex)
                {
                    selectedTournamentItemIndex = value;
                    MainVM.Instance.SelectedTournament = TournamentList[selectedTournamentItemIndex];
                    MainVM.Instance.TournamentName = TournamentList[selectedTournamentItemIndex].TournamentName;
                    Rounds = RoundsAsString();
                    NotifyPropertyChanged();
                }
            }
        }

        private string rounds;
        public string Rounds
        {
            get { return rounds; }
            set
            {
                if (value != rounds)
                {
                    rounds = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        public TournamentVM()
        {
            CommandCreateTournament = new Command(ExecuteCommandCreateTournament, CanExecuteCommandCreateTournament);
            CommandDeleteTournament = new Command(ExecuteCommandDeleteTournament, CanExecuteCommandDeleteTournament);
            CommandUpdateSelection = new Command(ExecuteCommandUpdateSelection);
            CommandCreateRound = new Command(ExecuteCommandCreateRound, CanExecuteCommandCreateRound);
            TournamentList = TournamentRepository.Instance.GetTournaments();
            ComboboxValues = new ObservableCollection<int>() { 1, 2, 3, 4 };
            SD = new SaveData();
        }

        private void ExecuteCommandUpdateSelection(object parameter)
        {
        }


        private void ExecuteCommandCreateRound(object parameter)
        {
            ObservableCollection<Player> playersInGame = new ObservableCollection<Player>();

            foreach (var player in MainVM.Instance.SelectedTournament.Players.Where(p => p.Defeated == false))
                playersInGame.Add(player);

            MatchMaker mm = new MatchMaker(SelectedMaxValue, SelectedMinValue, playersInGame);
            Round round = mm.GetNewRound();
            round.RoundName = (MainVM.Instance.SelectedTournament.Rounds.Count + 1).ToString();

            MainVM.Instance.SelectedTournament.Rounds.Add(round);

            Rounds = RoundsAsString();
        }

        private bool CanExecuteCommandCreateRound(object parameter)
        {
            if (MainVM.Instance.SelectedTournament != null && MainVM.Instance.SelectedTournament.Players.Count > SelectedMinValue)
                return true;

            return false;
        }

        private bool CanExecuteCommandDeleteTournament(object parameter)
        {
            if (SelectedTournamentItemIndex != -1)
            {
                return true;
            }
            return false;
        }

        private void ExecuteCommandDeleteTournament(object parameter)
        {
            TournamentList.Remove(TournamentList[SelectedTournamentItemIndex]);
        }

        private bool CanExecuteCommandCreateTournament(object parameter)
        {
            if (!string.IsNullOrEmpty(TournamentName) || !string.IsNullOrEmpty(GameName))
            {
                return true;
            }
            return false;
        }

        private void ExecuteCommandCreateTournament(object parameter)
        {
            Tournament newTournament = new Tournament();
            newTournament.TournamentName = TournamentName;
            newTournament.GameName = GameName;
            TournamentRepository.Instance.AddTournamentToList(newTournament);
            SD.SaveTournament(newTournament);

            if (TournamentList.Count == 1)
                MainVM.Instance.playerVM.SelectedTournament = TournamentList[0];

            if (newTournament.TournamentName == "Spanish")
            {
                GeneratePlayers(newTournament); //slettes (sammen med klassen Names og filen)
            }
        }

        void GeneratePlayers(Tournament tournament)
        {
            Names.GetNames();
            List<string> firstNames = Names.FirstNames;
            List<string> lastNames = Names.LastNames;

            for (int i = 0; i < firstNames.Count; i++)
            {
                Player player = new Player() { FirstName = firstNames[i], LastName = lastNames[i] };
                tournament.Players.Add(player);
            }
        }

        private string RoundsAsString()
        {
            StringBuilder builder = new StringBuilder();

            if (MainVM.Instance.SelectedTournament != null && MainVM.Instance.SelectedTournament.Rounds.Count > 0)
            {
                foreach (var item in MainVM.Instance.SelectedTournament.Rounds)
                {
                    builder.Append("\n" + "Runde: " + item.RoundName);
                    builder.Append("\n" + "Antal Matchgrupper: " + item.Matches.Count + "\n");
                }
            }
            return builder.ToString();
        }
    }
}