﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    public class UsersDB : IUsers, IAutoIncrement
    {

        private MySqlConnection conn;

        public UsersDB()
        {
            conn = DatabaseConnection.GetConnection();
        }

        public void AddUser(User user)
        {
            try
            {
                string sql = "INSERT INTO synaccounts (ID, Username, Password, FirstName, LastName, Email, Phone, Type) VALUES (@ID, @Username, @Password, @FirstName, @LastName, @Email, @Phone, @Type);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ID", user.Account.ID);
                cmd.Parameters.AddWithValue("@Username", user.Account.Username);
                cmd.Parameters.AddWithValue("@Password", user.Account.Password);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Type", user.Type);

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Account was not added successfully");
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

        }

        public void DeleteUser(User user)
        {
            try
            {
                string sql = "DELETE FROM synaccounts WHERE ID=@ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("ID", user.Account.ID);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //
                }
                else
                {
                    //
                }
            }
            catch (Exception ex)
            {

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

        public List<User> ReadUsers()
        {
            List<User> users = new List<User>();
            try
            {
                string sql = "SELECT ID, Username, Password, FirstName, LastName, Email, Phone, Type FROM synaccounts";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    users.Add(new User(new Account(Convert.ToInt32(dr["ID"]), dr["Username"]?.ToString(), dr["Password"]?.ToString()), dr["FirstName"]?.ToString(), dr["LastName"]?.ToString(), dr["Email"]?.ToString(), dr["Phone"]?.ToString(), dr["Type"]?.ToString()));
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            try
            {
                string sql = "UPDATE synaccounts SET ID=@ID, Username=@Username, Password=@Password, FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, Type=@Type";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@ID", user.Account.ID);
                cmd.Parameters.AddWithValue("@Username", user.Account.Username);
                cmd.Parameters.AddWithValue("@Password", user.Account.Password);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@Type", user.Type);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //
                }
                else
                {
                    //
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
