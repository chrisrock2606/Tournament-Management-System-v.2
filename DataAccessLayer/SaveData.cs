using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DomainLayer;
using System.Collections.ObjectModel;


namespace DataAccessLayer
{
    public class SaveData
    {
        public void SaveTeam(Team newTeam , int LeagueId)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> TeamList = new ObservableCollection<IID>();
            TeamList = GD.GetTeamID();
            newTeam.TeamId = GetID(TeamList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertTeam", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeamID", newTeam.TeamId);
                cmd.Parameters.AddWithValue("@TeamName", newTeam.TeamName);
                cmd.Parameters.AddWithValue("@LeagueID", LeagueId);
                cmd.Parameters.AddWithValue("@Bye", Convert.ToInt16(newTeam.Bye));

                cmd.ExecuteNonQuery();

                SavePlayersInTeams(newTeam.PlayersInTeam.First().ID , newTeam.TeamId);

                


            }
            catch (SqlException e)
            {
                throw e;
                
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }

        }

            internal int SaveLeague(League newLeague)
            {
            GetData GD = new GetData();
            ObservableCollection<IID> LeagueList = new ObservableCollection<IID>();
            LeagueList = GD.GetLeagueID();
            newLeague.LeagueId = GetID(LeagueList);


                SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
                try
                {
                    DBcon.Open();
                    SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                    cmd.CommandType = CommandType.StoredProcedure;
  
                    cmd.Parameters.AddWithValue("@LeagueID", newLeague.LeagueId);
                    cmd.Parameters.AddWithValue("@LeagueName", newLeague.LeagueName);
                    cmd.Parameters.AddWithValue("@Reward", newLeague.Reward);
                    cmd.Parameters.AddWithValue("@GameName", newLeague.GameName);
                    cmd.Parameters.AddWithValue("@LeagueStatus", newLeague.LeagueStatus);
  
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                throw e;
                }
                finally
                {
                    DBcon.Close();
                    DBcon.Dispose();
                }
            return newLeague.LeagueId;
        }

            public int SavePlayer(Player newPlayer)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> PlayerList = new ObservableCollection<IID>();
            PlayerList = GD.GetPlayerID();
            newPlayer.PlayerId = GetID(PlayerList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", newPlayer.PlayerId);
                cmd.Parameters.AddWithValue("@FirstName", newPlayer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", newPlayer.LastName);
                cmd.Parameters.AddWithValue("@Email", newPlayer.Email);
                cmd.Parameters.AddWithValue("@phoneNr", newPlayer.PhoneNr);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {

                throw;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
            return newPlayer.PlayerId;
        }

        public void SaveRound(Round newRound, int leagueId)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> roundList = new ObservableCollection<IID>();
            roundList = GD.GetRoundID();
            newRound.RoundId = GetID(roundList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertRound", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoundID", newRound.RoundId);
                cmd.Parameters.AddWithValue("@RoundName", newRound.RoundName);
                cmd.Parameters.AddWithValue("@LeagueID", leagueId);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }

        }

        public int SaveMatch(Match newMatch, int roundId)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> MatchList = new ObservableCollection<IID>();
            MatchList = GD.GetMatchID();
            newMatch.MatchId = GetID(MatchList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertMatch", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MatchID", newMatch.MatchId);
                cmd.Parameters.AddWithValue("@RoundID", roundId);

                cmd.ExecuteNonQuery();

                SaveTeamsInMatch(newMatch);
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
            return newMatch.MatchId;
        }

        private void SaveTeamsInMatch(Match newMatch)
        {
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                foreach (Team item in newMatch.TeamsInMatch)
                {
                    SqlCommand cmd = new SqlCommand("InsertTeamInMatch", DBcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                
                    cmd.Parameters.AddWithValue("@MatchID", newMatch.MatchId);
                    cmd.Parameters.AddWithValue("@TeamID", item.TeamId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        public void SavePlayersInTeams(int playerId , int teamId)
        {
             
 
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
 
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayersInTeam", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;
 
                cmd.Parameters.AddWithValue("@PlayerID", playerId);
                cmd.Parameters.AddWithValue("@TeamID", teamId);
 
                cmd.ExecuteNonQuery();
 
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }
        public void InsertPointsInTeam(Team team , Match match , int objectivePoints , int winnerPoints)
        {


            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayersInTeam", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeamID", team.TeamId);
                cmd.Parameters.AddWithValue("@MatchID", match.MatchId);
                cmd.Parameters.AddWithValue("@ObjectivePoints", objectivePoints);
                cmd.Parameters.AddWithValue("@WinnerPoints", winnerPoints);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        public int GetID(ObservableCollection<IID> ItemList)
        {
            int ItemID = 1;
            if (ItemList.Count != 0)
            {
                ItemID = ItemList[ItemList.Count - 1].ID + 1;
            }
            return ItemID;
        }
    }
}

