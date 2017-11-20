using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Domain
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
