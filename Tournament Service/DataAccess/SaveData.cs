using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DataAccess
{
    public class SaveData
    {
        public void SaveTournament(Tournament newTournament)
        {
            using (var db = new TournamentContext())
            {
                db.Tournaments.Add(newTournament);
                db.SaveChanges();
            }
        }

        public bool TryToSavePlayerToTournament(Player newPlayer, int tournamentId)
        {
            using (var db = new TournamentContext())
            {
                List<Tournament> Tournaments = db.Tournaments.ToList();
                foreach (var item in Tournaments)
                {
                    if (item.TournamentId == tournamentId)
                    {
                        item.PlayersInTournament.Add(newPlayer);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
