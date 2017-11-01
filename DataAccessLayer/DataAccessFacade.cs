using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DataAccessLayer
{
    public static class DataAccessFacade
    {

        public static void UpdateLeagueStatus(int leagueId, string leagueStatus)
        {
            UpdateData UD = new UpdateData();
            UD.UpdateLeagueStatus(leagueId, leagueStatus);
        }
        
        public static ObservableCollection<League> GetLeagueData()
        {
            GetData GD = new GetData();
            return GD.GetLeagues();

        }

        public static ObservableCollection<Player> GetPlayerData()
        {
            GetData GD = new GetData();
            return GD.GetPlayers();
        }

        public static int SaveLeague(League newLeague)
        {
            SaveData SD = new SaveData();
            return SD.SaveLeague(newLeague);
        }

        public static void SaveRound(Round newRound, int leagueId)
        {
            SaveData SD = new SaveData();
            SD.SaveRound(newRound, leagueId);
        }

        public static int SavePlayer(Player newPlayer)
        {
            SaveData SD = new SaveData();
            return SD.SavePlayer(newPlayer);
        }

        public static void UpdatePlayer(Player ChosenPlayer)
        {
            UpdateData UD = new UpdateData();
            UD.UpdatePlayer(ChosenPlayer);
        }

        public static void DeleteLeague(League chosenLeague)
        {
            DeleteData DL = new DeleteData();
            DL.DeleteLeague(chosenLeague);
        }

        public static void DeletePlayer(Player ChosenPlayer)
        {
            DeleteData DL = new DeleteData();
            DL.DeletePlayer(ChosenPlayer);
        }

        public static void SaveMatch(Match newMatch, int roundId)
        {
            SaveData SD = new SaveData();
            SD.SaveMatch(newMatch, roundId);
            
        }

        public static Player GetPlayerById(int playerId)
        {
            GetData GD = new GetData();
            return GD.GetPlayerById(playerId);
        }
    }
}
