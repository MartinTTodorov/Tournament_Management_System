using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class MatchesDB : ImatchesDB<Match>
    {
        private MySqlConnection conn;
        public MatchesDB()
        {
            conn = DatabaseConnection.GetConnection();
        }

        public void AddMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void SetMatchResults(Match match)
        {
            try
            {
                string sql = "UPDATE synwholetournaments SET Player1Score=@Player1Score, Player2Score = @Player2Score WHERE MatchID = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Player1Score", match.Player1Score);
                cmd.Parameters.AddWithValue("@Player2Score", match.Player2Score);
                cmd.Parameters.AddWithValue("@ID", match.ID);

                if (cmd.ExecuteNonQuery()!=1)
                {
                    throw new Exception("Match results were not uploaded into the database");
                }
            }
            catch (MySqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
