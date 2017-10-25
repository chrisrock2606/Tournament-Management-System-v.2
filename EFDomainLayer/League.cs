using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DomainLayer
{
    
    public class League : IID
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string GameName { get; set; }
        public string Reward { get; set; }
        public int Rounds { get; set; }
        public string LeagueStatus { get; set; }
        public ObservableCollection<Team> TeamsInLeague { get; set; }
        public ObservableCollection<Round> RoundsInLeague { get; set; }
        public int ID
        {
            get { return LeagueId; }

            set { LeagueId = value; }
        }

        
    }
}
