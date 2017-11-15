using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DomainLayer
{
    
    public class Tournament : INotifyPropertyChanged, IID
    {
        private int tournamentId;
        private string tournamentName;
        private string gameName;
        private string reward;
        private string tournamentStatus;

        public int TournamentId
        {
            get { return tournamentId; }
            set
            {
                if (tournamentId != value)
                {
                    tournamentId = value;
                    RaisePropertyChanged("TournamentId");
                }
            }
        }
        public string TournamentName
        {
            get { return tournamentName; }
            set
            {
                if (tournamentName != value)
                {
                    tournamentName = value;
                    RaisePropertyChanged("TournamentName");
                }
            }
        }
        public string GameName
        {
            get { return gameName; }
            set
            {
                if (gameName != value)
                {
                    gameName = value;
                    RaisePropertyChanged("GameName");
                }
            }
        }
        public string Reward
        {
            get { return reward; }
            set
            {
                if (reward != value)
                {
                    reward = value;
                    RaisePropertyChanged("Reward");
                }
            }
        }
        public string TournamentStatus
        {
            get { return tournamentStatus; }
            set
            {
                if (tournamentStatus != value)
                {
                    tournamentStatus = value;
                    RaisePropertyChanged("TournamentStatus");
                }
            }
        }

        public ObservableCollection<Player> PlayersInLeague { get; set; }
        public ObservableCollection<Round> RoundsInLeague { get; set; }

        public int ID
        {
            get { return TournamentId; }

            set { TournamentId = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
