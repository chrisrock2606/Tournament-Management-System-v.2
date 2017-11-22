using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class GetData
    {
        public List<Tournament> GetTournaments()
        {
            using (var db = new TournamentContext())
            {
                return db.Tournaments.ToList();
            }
        }
        
    }
}
