using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Round : IID
    {
        public int RoundId { get; set; }
        public string RoundName { get; set; }
        public ObservableCollection<Team> TeamsInRound { get; set; }
        public ObservableCollection<Match> MatchesInRound { get; set; }
        public int ID
        {
            get { return RoundId; }

            set { RoundId = value; }
        }
    }
}
