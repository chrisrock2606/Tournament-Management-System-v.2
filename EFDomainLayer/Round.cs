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
    public class Round : ModelBase
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
                    NotifyPropertyChanged();
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
                    NotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<Match> Matches { get; set; }
        public int Id { get; set; }

        public Round()
        {
            Matches = new ObservableCollection<Match>();
            Id = IdService.Instance.GetNewId();
        }
    }
}
