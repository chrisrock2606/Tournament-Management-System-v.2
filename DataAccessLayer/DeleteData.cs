using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DomainLayer;

namespace DataAccessLayer
{
    class DeleteData
    {
        internal void DeletePlayer(Player ChosenPlayer)
        {
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("DeletePlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", ChosenPlayer.ID);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("ups " + e.Message);
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        internal void DeleteLeague(League chosenLeague)
        {
            {
                SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
                try
                {
                    DBcon.Open();
                    SqlCommand cmd = new SqlCommand("DeleteLeague", DBcon);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LeagueID", chosenLeague.ID);

                    cmd.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("ups " + e.Message);
                }
                finally
                {
                    DBcon.Close();
                    DBcon.Dispose();
                }
            }
        }
    }
}
