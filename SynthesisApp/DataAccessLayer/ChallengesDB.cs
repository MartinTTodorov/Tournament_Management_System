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
            string sql = "UPDATE synchallenges SET ChallengeStatus = @ChallengeStatus WHERE OpponentID=@OpponentID";
            try
            {

            }
            catch (MySqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        public void ChallengeUser(int challengerID, int opponentID)
        {
            string sql = "INSERT INTO synchallenges (ChallengerID, OpponentID, ChallengeStatus) VALUES (@ChallengerID, @OpponentID, @ChallengeStatus)";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ChallengerID", challengerID);
                cmd.Parameters.AddWithValue("@OpponentID", opponentID);
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

            }
        }

        public void ChangeChallengeStatus(Challenge challenge, string status)
        {
            string sql = "UPDATE synchallenges SET ChallengeStatus = @ChallengeStatus WHERE OpponentID=@OpponentID";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@OpponentID", challenge.OpponentID);
                cmd.Parameters.AddWithValue("@ChallengeStatus", status);

                if (cmd.ExecuteNonQuery()!=1)
                {
                    throw new Exception("The challenge status was not updated");
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
            throw new NotImplementedException();
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
                string sql = "SELECT ChallengeID, ChallengerID, OpponentID, ChallengeStatus FROM synchallenges";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    challenges.Add(new Challenge(Convert.ToInt32(dr["ChallengeID"]), Convert.ToInt32(dr["ChallengerID"]), Convert.ToInt32(dr["OpponentID"]), dr["ChallengeStatus"].ToString()));
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
    }
}
