using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Domain;

namespace Tournament_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        void SaveTournament(Tournament newTournament);

        [OperationContract]
        bool TryToSavePlayerToTournament(Player newPlayer, int tournamentId);

        [OperationContract]
        List<Tournament> GetTournaments();

        

        // TODO: Add your service operations here
    }
}
