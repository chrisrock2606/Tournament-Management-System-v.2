using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Domain
{
    public class Match : INotifyPropertyChanged, IID
    {
        private int matchId;
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
        public ObservableCollection<Player> PlayersInMatch { get; set; }

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
