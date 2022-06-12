using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class ChallengesDB : IChallengesDB, IAutoIncrement
    {
        private MySqlConnection conn;

        public ChallengesDB()
        {
            conn = DatabaseConnection.GetConnection();
        }

        public void AcceptChallenge(Challenge challenge)
        {
            string sql = "UPDATE synchallenges SET ChallengeStatus = @ChallengeStatus WHERE ChallengeID=@ChallengeID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ChallengeID", challenge.ID);
                cmd.Parameters.AddWithValue("@ChallengeStatus", "Accepted");

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("The challenge was not accepted");
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

        public void ChallengeUser(Challenge challenge)
        {
            string sql = "INSERT INTO synchallenges (ChallengerID, OpponentID, ChallengerScore, OpponentScore, Date, Sport, ChallengeStatus) VALUES (@ChallengerID, @OpponentID, @ChallengerScore, @OpponentScore, @Date, @Sport, @ChallengeStatus)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChallengerID", challenge.ChallengerID);
                cmd.Parameters.AddWithValue("@OpponentID", challenge.OpponentID);
                cmd.Parameters.AddWithValue("@Date", challenge.Date);
                cmd.Parameters.AddWithValue("@Sport", challenge.Match.Sport);
                cmd.Parameters.AddWithValue("@ChallengerScore", challenge.Match.Player1Score);
                cmd.Parameters.AddWithValue("@OpponentScore", challenge.Match.Player2Score);
                cmd.Parameters.AddWithValue("@ChallengeStatus", "Awaiting");
                if (cmd.ExecuteNonQuery() != 1)
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

        

        public void DenyChallenge(Challenge challenge)
        {
            string sql = "UPDATE synchallenges SET ChallengeStatus = @ChallengeStatus WHERE ChallengeID=@ChallengeID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ChallengeID", challenge.ID);
                cmd.Parameters.AddWithValue("@ChallengeStatus", "Denied");

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("The challenge was not denied");
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

        public int GetID()
        {
            string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi481796' AND TABLE_NAME = 'synaccounts';";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Challenge> ReadChallenges()
        {
            List<Challenge> challenges = new List<Challenge>();

            try
            {
                string sql = "SELECT ChallengeID, ChallengerID, OpponentID, ChallengerScore, OpponentScore, Date, Sport, ChallengeStatus FROM synchallenges";
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    challenges.Add(new Challenge(Convert.ToInt32(dr["ChallengeID"]), Convert.ToInt32(dr["ChallengerID"]), Convert.ToInt32(dr["OpponentID"]), Convert.ToDateTime(dr["Date"]), new Match(Convert.ToInt32(dr["ChallengerScore"]), Convert.ToInt32(dr["OpponentScore"]), SportType.SportTypes.Find(x => x.ToString() == dr["Sport"].ToString())), dr["ChallengeStatus"].ToString()));
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
            return challenges;
        }

        //Set results of a challenge and set status to finished
        public void SetResults(Challenge challenge)
        {
            string sql = "UPDATE synchallenges SET ChallengerScore = @ChallengerScore, OpponentScore = @OpponentScore, ChallengeStatus = @ChallengeStatus WHERE ChallengeID=@ChallengeID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ChallengeID", challenge.ID);
                cmd.Parameters.AddWithValue("@ChallengerScore", challenge.Match.Player1Score);
                cmd.Parameters.AddWithValue("@OpponentScore", challenge.Match.Player2Score);
                cmd.Parameters.AddWithValue("@ChallengeStatus", "Finished");

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("The challenge results were not set");
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
