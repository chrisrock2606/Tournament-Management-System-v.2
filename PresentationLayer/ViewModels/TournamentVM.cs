using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
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

        #endregion

        public TournamentVM()
        {
            CommandCreateTournament = new Command(ExecuteCommandCreateTournament, CanExecuteCommandCreateTournament);
            TournamentList = TournamentRepository.Instance.TournamentList;
        }

        private bool CanExecuteCommandCreateTournament(object parameter)
        {
            return true;
        }

        private void ExecuteCommandCreateTournament(object parameter)
        {
            Tournament newTournament = new Tournament();
            newTournament.TournamentName = TournamentName;
            newTournament.GameName = GameName;
            TournamentRepository.Instance.AddTournamentToList(newTournament);
        }
    }

    
}