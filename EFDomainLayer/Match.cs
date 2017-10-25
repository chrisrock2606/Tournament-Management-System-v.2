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
    public class Match : IID
    {
        public int MatchId { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public ObservableCollection<Team> TeamsInMatch { get; set; }
        public string VsString { get; set; }

        public int ID
        {
            get { return MatchId; }

            set { MatchId = value; }
        }

        public Match()
        {
            TeamsInMatch = new ObservableCollection<Team>();
            TeamsInMatch.Add(Team1);
            TeamsInMatch.Add(Team2);
            VsString = "VS";
        }
    }
}
