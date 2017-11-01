using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Round : IID
    {
        private int roundId;
        private string roundName;
        public int RoundId
        {
            get { return roundId; }
            set
            {
                if (roundId != value)
                {
                    roundId = value;
                    RaisePropertyChanged("RoundId");
                }
            }
        }
        public string RoundName
        {
            get { return roundName; }
            set
            {
                if (roundName != value)
                {
                    roundName = value;
                    RaisePropertyChanged("RoundName");
                }
            }
        }
        public ObservableCollection<Player> PlayersInRound { get; set; }
        public ObservableCollection<Match> MatchesInRound { get; set; }
        public int ID
        {
            get { return RoundId; }

            set { RoundId = value; }
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
