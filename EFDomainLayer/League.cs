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
    
    public class League : INotifyPropertyChanged, IID
    {
        private int leagueId;
        private string leagueName;
        private string gameName;
        private string reward;
        private string leagueStatus;

        public int LeagueId
        {
            get { return leagueId; }
            set
            {
                if (leagueId != value)
                {
                    leagueId = value;
                    RaisePropertyChanged("LeagueId");
                }
            }
        }

        public string LeagueName
        {
            get { return leagueName; }
            set
            {
                if (leagueName != value)
                {
                    leagueName = value;
                    RaisePropertyChanged("LeagueName");
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

        public string LeagueStatus
        {
            get { return leagueStatus; }
            set
            {
                if (leagueStatus != value)
                {
                    leagueStatus = value;
                    RaisePropertyChanged("LeagueStatus");
                }
            }
        }

        public ObservableCollection<Player> PlayersInLeague { get; set; }

        public ObservableCollection<Round> RoundsInLeague { get; set; }
        public int ID
        {
            get { return LeagueId; }

            set { LeagueId = value; }
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
