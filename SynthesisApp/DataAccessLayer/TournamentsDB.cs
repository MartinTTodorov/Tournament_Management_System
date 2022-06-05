using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class TournamentsDB : ITournaments<Tournament>, IAutoIncrement
    {
        private MySqlConnection conn = new MySqlConnection("Server = studmysql01.fhict.local; Uid=dbi481796;Database=dbi481796;Pwd=sql7915");

        
        public void AddTournament(Tournament tournament)
        {
            try
            {
                string sql = "INSERT INTO tournament (TournamentID, Info, Location, StartDate, EndDate, MinPlayers, MaxPlayers, Type, Status) VALUES(@ID, @Info, @Location, @StartDate, @EndDate, @MinPlayers, @MaxPlayers, @Type, @Status)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("ID", tournament.ID);
                cmd.Parameters.AddWithValue("Info", tournament.TournamentInfo);
                cmd.Parameters.AddWithValue("Location", tournament.Location);
                cmd.Parameters.AddWithValue("StartDate", tournament.StartDate);
                cmd.Parameters.AddWithValue("EndDate", tournament.EndDate);
                cmd.Parameters.AddWithValue("MinPlayers", tournament.MinPlayers);
                cmd.Parameters.AddWithValue("MaxPlayers", tournament.MaxPlayers);
                cmd.Parameters.AddWithValue("Type", tournament.TournamentType); //do i need to check if this is a string
                cmd.Parameters.AddWithValue("Status", tournament.TournamentStatus);

                if (cmd.ExecuteNonQuery()!=1)
                {
                    throw new Exception("Tournament was not added successfully");
                }

            }
            catch (MySqlException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            
        }

        public void DeleteTournament(Tournament tournament)
        {
            try
            {
                string sql = "DELETE FROM tournament WHERE TournamentID=@ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("ID", tournament.ID);

                if (cmd.ExecuteNonQuery()!=1)
                {
                    throw new Exception("Tournament was not deleted sucessfully");
                }
                else
                {
                    
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The next auto incremented ID in a database table</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetID()
        {
            string sql = "SELECT AUTO_INCREMENT FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbi481796' AND TABLE_NAME = 'tournament';";
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

        public List<Tournament> ReadTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                string sql = "SELECT TournamentID, Info, Location, StartDate, EndDate, MinPlayers, MaxPlayers, Type, Status FROM tournament";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tournaments.Add(new Tournament(Convert.ToInt32(dr["TournamentID"]), TournamentType.TournamentTypes.Find(x => x.ToString() == dr["Type"].ToString()), dr["Info"].ToString(), Convert.ToDateTime(dr["StartDate"]), Convert.ToDateTime(dr["EndDate"]), Convert.ToInt32(dr["MinPlayers"]), Convert.ToInt32(dr["MaxPlayers"]), dr["Location"].ToString(), dr["Status"].ToString()));
                }
            }
            catch (MySqlException ex)
            {

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return tournaments;
        }

        public void UpdateTournament(Tournament tournament)
        {
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
    }
}

