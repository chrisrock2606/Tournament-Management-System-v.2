using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DataAccess;
using Domain;

namespace Tournament_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public void SaveTournament(Tournament newTournament)
        {
            SaveData SD = new SaveData();
            SD.SaveTournament(newTournament);
        }

        public bool TryToSavePlayerToTournament(Player newPlayer, int tournamentId)
        {
            SaveData SD = new SaveData();
            return SD.TryToSavePlayerToTournament(newPlayer, tournamentId);
        }
        public List<Tournament> GetTournaments()
        {
            GetData GD = new GetData();
            return GD.GetTournaments();
        }

        
    }
}
