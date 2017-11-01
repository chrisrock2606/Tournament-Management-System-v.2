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
