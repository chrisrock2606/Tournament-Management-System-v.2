using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAccessLayer.TournamentService;
using DomainLayer;
using Player = DomainLayer.Player;
using Round = DomainLayer.Round;

namespace ServiceAccessLayer
{
    public class SaveData
    {
        private IService TS;
        private TournamentService.Tournament dummyTournament;

        public SaveData()
        {
            TS = new ServiceClient();
        }

        public void SaveTournament(DomainLayer.Tournament newTournament)
        {
            dummyTournament = new TournamentService.Tournament();
            dummyTournament.ID = newTournament.ID;
            dummyTournament.GameName = newTournament.GameName;
            dummyTournament.Reward = newTournament.Reward;
            dummyTournament.TournamentName = newTournament.TournamentName;
            dummyTournament.TournamentStatus = newTournament.TournamentStatus;
            SavePlayers(newTournament.Players);
            SaveRounds(newTournament.Rounds);
        }

        private void SaveRounds(ObservableCollection<Round> newRounds)
        {
            for (int i = 0; i < newRounds.Count; i++)
            {
                dummyTournament.RoundsInTournament[i].ID = newRounds[i].ID;
                dummyTournament.RoundsInTournament[i].RoundName = newRounds[i].RoundName;

            }
        }

        private void SavePlayers(ObservableCollection<Player> NewPlayers)
        {
            for (int i = 0; i < NewPlayers.Count; i++)
            {
                dummyTournament.PlayersInTournament[i].ID = NewPlayers[i].ID;
                dummyTournament.PlayersInTournament[i].FirstName = NewPlayers[i].FirstName;
                dummyTournament.PlayersInTournament[i].LastName = NewPlayers[i].LastName;
                dummyTournament.PlayersInTournament[i].Email = NewPlayers[i].Email;
                dummyTournament.PlayersInTournament[i].PhoneNr = NewPlayers[i].PhoneNr;
                dummyTournament.PlayersInTournament[i].UserName = NewPlayers[i].UserName;
            }
        }
    }
}
