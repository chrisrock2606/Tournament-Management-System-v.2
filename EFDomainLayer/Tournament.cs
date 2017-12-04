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
    
    public class Tournament : ModelBase
    {
        private string tournamentName;
        private string gameName;
        private string reward;
        private string tournamentStatus;
        public string TournamentName
        {
            get { return tournamentName; }
            set
            {
                if (tournamentName != value)
                {
                    tournamentName = value;
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<Round> Rounds { get; set; }

        public int Id { get; set; }

        public Tournament()
        {
            Players = new ObservableCollection<Player>();
            Rounds = new ObservableCollection<Round>();
            Id = IdService.Instance.GetNewId();
        }
    }
}
