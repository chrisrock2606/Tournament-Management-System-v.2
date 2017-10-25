using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using DomainLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UpdateData
    {

        internal void UpdatePlayer(Player ChosenPlayer)
        {

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("UpdatePlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", ChosenPlayer.ID);
                cmd.Parameters.AddWithValue("@FirstName", ChosenPlayer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", ChosenPlayer.LastName);
                cmd.Parameters.AddWithValue("@Email", ChosenPlayer.Email);
                cmd.Parameters.AddWithValue("@PhoneNr", ChosenPlayer.PhoneNr);

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

        internal void UpdateLeagueStatus(int leagueId, string leagueStatus)
        {
            //opretter et objekt der indeholder en connection string til databasen
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
            try
            {
                //åbner forbindelsen til databasen
                DBcon.Open();

                //opretter et objekt med parametrerne: en string med navnet på den stored procedure som bruges
                //og det objekt der indeholder forbindelsen til databasen
                SqlCommand cmd = new SqlCommand("UpdateLeagueStatus", DBcon);

                //angiver hvad for en type comando der skal udføres 
                cmd.CommandType = CommandType.StoredProcedure;

                //tilføjer parametrerne den stored procedure skal bruge
                cmd.Parameters.AddWithValue("@LeagueID", leagueId);
                cmd.Parameters.AddWithValue("@LeagueStatus", leagueStatus);

                //udføre komandoen
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                // lukker for database forbindelsen
                DBcon.Close();
                //sletter forbindelses objektet
                DBcon.Dispose();
            }
        }

        internal void UpdateTeam(Team ChosenTeam)
        {
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("UpdateTeamByeStatus", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeamID", ChosenTeam.TeamId);
                cmd.Parameters.AddWithValue("@ByeStatus", ChosenTeam.Bye);
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
    }
}
