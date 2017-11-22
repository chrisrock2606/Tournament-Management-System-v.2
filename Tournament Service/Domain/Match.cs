using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class Match : INotifyPropertyChanged, IID
    {
        private int matchId;
        [DataMember]
        public int MatchId
        {
            get { return matchId; }
            set
            {
                if (matchId != value)
                    {
                        matchId = value;
                        RaisePropertyChanged("MatchId");
                    }
            }
        }
        [DataMember]
        public ObservableCollection<Player> PlayersInMatch { get; set; }

        [DataMember]
        public int ID
        {
            get { return MatchId; }

            set { MatchId = value; }
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
