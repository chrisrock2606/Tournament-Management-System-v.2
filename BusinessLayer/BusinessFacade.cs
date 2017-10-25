using System;
using System.Collections.ObjectModel;
using DataAccessLayer;
using DomainLayer;
using Match = System.Text.RegularExpressions.Match;

namespace BusinessLayer
{
    public static class BusinessFacade
    {

        public static void UpdateLeagueStatus(int LeagueId, string LeagueStatus)
        {
            DataAccessFacade.UpdateLeagueStatus(LeagueId, LeagueStatus);
        }


        public static ObservableCollection<League> GetLeagueData()
        {
            return DataAccessFacade.GetLeagueData();
        }

        public static ObservableCollection<Player> GetPlayerData()
        {
            return DataAccessFacade.GetPlayerData();
        }

        public static int SaveLeague(League newLeague)
        {
            return DataAccessFacade.SaveLeague(newLeague);
        }

        public static void SaveRound(Round newRound, int leagueId)
        {
            DataAccessFacade.SaveRound(newRound, leagueId);
        }


        public static int SavePlayer(Player newPlayer)
        {
            return DataAccessFacade.SavePlayer(newPlayer);
        }

        public static void UpdateTeam(Team ChosenTeam)
        {
            DataAccessFacade.UpdateTeam(ChosenTeam);
        }

        public static void SaveTeam(Team newTeam, int leagueId)
        {
            DataAccessFacade.SaveTeam(newTeam, leagueId);
        }


        public static void UpdatePlayer(Player ChosenPlayer)
        {
            DataAccessFacade.UpdatePlayer(ChosenPlayer);
        }

        public static void DeletePlayer(Player ChosenPlayer)
        {
            DataAccessFacade.DeletePlayer(ChosenPlayer);
        }

        public static void DeleteLeague(League chosenLeague)
        {
            DataAccessFacade.DeleteLeague(chosenLeague);
        }

        public static void CreateMatches(ObservableCollection<Team> TeamsInLeague, ObservableCollection<Round> RoundsInLeague)
        {
            MatchMaker MM = new MatchMaker();
            MM.CreateMatches(TeamsInLeague, RoundsInLeague);
        }

        public static ObservableCollection<Team> ShuffleTeam(ObservableCollection<Team> teamList)
        {
            MatchMaker MM = new MatchMaker();
            return MM.ShuffleTeams(teamList);
        }

        public static Player GetPlayerById(int playerId)
        {
            return DataAccessFacade.GetPlayerById(playerId);
        }
    }
}
