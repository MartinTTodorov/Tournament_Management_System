using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class TournamentsDB : ITournaments, IAutoIncrement
    {
        private MySqlConnection conn;

        public TournamentsDB()
        {
            conn = DatabaseConnection.GetConnection();
        }
        public void AddPlayer(Tournament tournament, User player)
        {
            try
            {
                string sql = "INSERT INTO synplayersintournament (TournamentID, PlayerID) VALUES(@TournamentID, @PlayerID)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@TournamentID", tournament.ID);
                cmd.Parameters.AddWithValue("PlayerID", player.Account.ID);

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Not joined succesfully");

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

        public void AddTournament(Tournament tournament)
        {
            try
            {
                string sql = "INSERT INTO tournament (Info, Title, Location, StartDate, EndDate, MinPlayers, MaxPlayers, Type, Sport, Status) VALUES(@Info, @Title, @Location, @StartDate, @EndDate, @MinPlayers, @MaxPlayers, @Type, @Sport, @Status)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("Title", tournament.Title);
                cmd.Parameters.AddWithValue("Info", tournament.TournamentInfo);
                cmd.Parameters.AddWithValue("Location", tournament.Location);
                cmd.Parameters.AddWithValue("StartDate", tournament.StartDate);
                cmd.Parameters.AddWithValue("EndDate", tournament.EndDate);
                cmd.Parameters.AddWithValue("MinPlayers", tournament.MinPlayers);
                cmd.Parameters.AddWithValue("MaxPlayers", tournament.MaxPlayers);
                cmd.Parameters.AddWithValue("Type", tournament.TournamentType);
                cmd.Parameters.AddWithValue("Sport", tournament.Sport);
                cmd.Parameters.AddWithValue("Status", tournament.TournamentStatus.ToString());

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

        public void CancelTournament(Tournament tournament)
        {
            try
            {
                string sql = "UPDATE tournament SET Status=@Status WHERE TournamentID=@TournamentID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Status", TournamentStatus.Cancelled.ToString());
                cmd.Parameters.AddWithValue("@TournamentID", tournament.ID);

                if (cmd.ExecuteNonQuery()!=1)
                {
                    throw new Exception("Tournament was not cancelled");
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

        public void CreateMatches(Tournament tournament)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                conn.Open();
                for (int i = 0; i < tournament.Matches.Count; i++)
                {

                    sql.Append($"INSERT INTO synwholetournaments (TournamentID, Player1ID, Player2ID, Player1Score, Player2Score, Sport) VALUES(@TournamentID, @Player1ID{i}, @Player2ID{i}, @Player1Score{i}, @Player2Score{i}, @Sport);");
                }
                sql.Append("UPDATE tournament SET Status =@Status WHERE TournamentID=@TournamentID;");
                MySqlCommand cmd = new MySqlCommand(sql.ToString(), conn);


                cmd.Parameters.AddWithValue("@TournamentID", tournament.ID);
                cmd.Parameters.AddWithValue("@Status", TournamentStatus.Scheduled.ToString());
                cmd.Parameters.AddWithValue("@Sport", tournament.Sport);
                for (int i = 0; i < tournament.Matches.Count; i++)
                {
                    //cmd.Parameters.AddWithValue($"MatchID{i}", tournament.Matches[i].ID);
                    cmd.Parameters.AddWithValue($"Player2ID{i}", tournament.Matches[i].Player2.Account.ID);
                    cmd.Parameters.AddWithValue($"Player1Score{i}", tournament.Matches[i].Player1Score);
                    cmd.Parameters.AddWithValue($"Player2Score{i}", tournament.Matches[i].Player2Score);
                    cmd.Parameters.AddWithValue($"Player1ID{i}", tournament.Matches[i].Player1.Account.ID);
                }

                if (cmd.ExecuteNonQuery()!=tournament.Matches.Count+1)
                {
                    throw new Exception("Matches were not created successfully");
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

        public void FinishTournament(Tournament tournament)
        {
            try
            {
                string sql = "UPDATE tournament SET Status=@Status WHERE TournamentID=@TournamentID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@Status", TournamentStatus.Finished.ToString());
                cmd.Parameters.AddWithValue("@TournamentID", tournament.ID);

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Tournament was not cancelled");
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of tournaments with the players if there are any</returns>
        public List<Tournament> ReadTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();

            try
            {
                string sql = "SELECT TournamentID, Title, Info, Location, StartDate, EndDate, MinPlayers, MaxPlayers, Type, Sport, Status FROM tournament; SELECT TournamentID, PlayerID, Username, Password, FirstName, LastName, Email, Phone, Type FROM synplayersintournament st INNER JOIN synaccounts sa ON st.PlayerID = sa.ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                
                
                adapter.Fill(ds);

                //while (dr.Read())
                //{
                //    tournaments.Add(new Tournament(Convert.ToInt32(dr["TournamentID"]), TournamentType.TournamentTypes.Find(x => x.ToString() == dr["Type"].ToString()), dr["Title"].ToString(), dr["Info"].ToString(), Convert.ToDateTime(dr["StartDate"]), Convert.ToDateTime(dr["EndDate"]), Convert.ToInt32(dr["MinPlayers"]), Convert.ToInt32(dr["MaxPlayers"]), dr["Location"].ToString(), (TournamentStatus)Enum.Parse(typeof(TournamentStatus), dr["Status"].ToString()))); 
                //}
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    tournaments.Add(new Tournament(Convert.ToInt32(ds.Tables[0].Rows[i][0]), TournamentType.TournamentTypes.Find(x=>x.ToString()==ds.Tables[0].Rows[i][8].ToString()), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), Convert.ToDateTime(ds.Tables[0].Rows[i][4]), Convert.ToDateTime(ds.Tables[0].Rows[i][5]), Convert.ToInt32(ds.Tables[0].Rows[i][6]), Convert.ToInt32(ds.Tables[0].Rows[i][7]), ds.Tables[0].Rows[i][3].ToString(), SportType.SportTypes.Find(x => x.ToString() == ds.Tables[0].Rows[i][9].ToString()), (TournamentStatus)Enum.Parse(typeof(TournamentStatus), ds.Tables[0].Rows[i][10].ToString())));

                    List<User> players = new List<User>();
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        if (tournaments[i].ID == Convert.ToInt32(ds.Tables[1].Rows[j][0])) 
                        {
                            players.Add(new User(new Account(Convert.ToInt32(ds.Tables[1].Rows[j][1]), ds.Tables[1].Rows[j][2].ToString(), ds.Tables[1].Rows[j][3].ToString()), ds.Tables[1].Rows[j][4].ToString(), ds.Tables[1].Rows[j][5].ToString(), ds.Tables[1].Rows[j][6].ToString(), ds.Tables[1].Rows[j][7].ToString(), ds.Tables[1].Rows[j][8].ToString()));
                        }
                    }
                    tournaments[i].AssignPlayers(players);

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
            return tournaments;
        }

        public List<Match> RetrieveMatches(Tournament tournament)
        {
            List<Match> matches = new List<Match>();
            try
            {
                User player1 = null;
                User player2 = null;
                string sql = "Select TournamentID, MatchID, Player1ID, Player2ID, Player1Score, Player2Score FROM synwholetournaments WHERE TournamentID=@ID; SELECT ID, Username, Password, FirstName, LastName, Email, Phone, Type FROM synaccounts";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@ID", tournament.ID);
                DataSet ds = new DataSet();
                
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
                    {
                        if (Convert.ToInt32(ds.Tables[0].Rows[i][2])==Convert.ToInt32(ds.Tables[1].Rows[j][0]))
                        {
                            player1 = new User(new Account(Convert.ToInt32(ds.Tables[1].Rows[j][0]), ds.Tables[1].Rows[j][1].ToString(), ds.Tables[1].Rows[j][2].ToString()), ds.Tables[1].Rows[j][3].ToString(), ds.Tables[1].Rows[j][4].ToString(), ds.Tables[1].Rows[j][5].ToString(), ds.Tables[1].Rows[j][6].ToString(), ds.Tables[1].Rows[j][7].ToString());
                        }

                        if (Convert.ToInt32(ds.Tables[0].Rows[i][3]) == Convert.ToInt32(ds.Tables[1].Rows[j][0]))
                        {
                            player2 = new User(new Account(Convert.ToInt32(ds.Tables[1].Rows[j][0]), ds.Tables[1].Rows[j][1].ToString(), ds.Tables[1].Rows[j][2].ToString()), ds.Tables[1].Rows[j][3].ToString(), ds.Tables[1].Rows[j][4].ToString(), ds.Tables[1].Rows[j][5].ToString(), ds.Tables[1].Rows[j][6].ToString(), ds.Tables[1].Rows[j][7].ToString());
                        }
                    }

                    matches.Add(new Match(Convert.ToInt32(ds.Tables[0].Rows[i][1]), player1, player2, Convert.ToInt32(ds.Tables[0].Rows[i][4]), Convert.ToInt32(ds.Tables[0].Rows[i][5]), tournament.Sport));
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

            return matches;

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

