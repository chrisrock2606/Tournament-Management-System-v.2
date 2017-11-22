using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class Round : IID
    {
        private int roundId;
        private string roundName;
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public ObservableCollection<Player> PlayersInRound { get; set; }
        [DataMember]
        public ObservableCollection<Match> MatchesInRound { get; set; }
        [DataMember]
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
