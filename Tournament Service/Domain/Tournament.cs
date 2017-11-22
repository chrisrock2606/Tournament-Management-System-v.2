using System.Collections.ObjectModel;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Domain;

namespace Domain
{
    [DataContract]
    public class Tournament : INotifyPropertyChanged, IID
    {
        private int tournamentId;
        private string tournamentName;
        private string gameName;
        private string reward;
        private string tournamentStatus;

        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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

        [DataMember]
        public ObservableCollection<Player> PlayersInTournament { get; set; }
        [DataMember]
        public ObservableCollection<Round> RoundsInTournament { get; set; }

        [DataMember]
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
