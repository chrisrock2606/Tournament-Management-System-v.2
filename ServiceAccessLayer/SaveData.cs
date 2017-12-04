using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAccessLayer.TournamentService;
using DomainLayer;

namespace ServiceAccessLayer
{
    public class SaveData
    {
        private IService TS;

        public SaveData()
        {
            TS = new ServiceClient();
        }

        public void SaveTournament(DomainLayer.Tournament newTournament)
        {
            TournamentService.Tournament dummyTournament = new TournamentService.Tournament();
            dummyTournament.
        }
    }
}
