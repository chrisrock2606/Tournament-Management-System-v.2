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

namespace PresentationLayer.ViewModels
{
    class TournamentVM : ModelBase
    {
        #region Properties

        public ObservableCollection<Tournament> TournamentList { get; set; }

        public ICommand CommandCreateTournament { get; set; }
        public ICommand CommandDeleteTournament { get; set; }
        public ICommand CommandUpdateSelection { get; set; }

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
            TournamentList = TournamentRepository.Instance.TournamentList;
        }

        private void ExecuteCommandUpdateSelection(object parameter)
        {
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
            int newTournamentId;
            if (TournamentList.Count == 0)
            {
                newTournamentId = 1;
            }
            else
            {
                TournamentList.OrderBy(x => x.ID);
                newTournamentId = TournamentList[TournamentList.Count - 1].ID + 1;
            }
            Tournament newTournament = new Tournament();
            newTournament.ID = newTournamentId;
            newTournament.TournamentName = TournamentName;
            newTournament.GameName = GameName;
            TournamentRepository.Instance.AddTournamentToList(newTournament);
        }

        internal Tournament GetSelectedTournament()
        {
            if (selectedTournamentItemIndex != -1)
            {
                return TournamentList[selectedTournamentItemIndex];
            }
            else
            {
                throw new DataException("No Item Selected");
            }
        }
    }

    
}