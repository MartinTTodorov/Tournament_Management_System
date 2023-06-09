﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer
{
    public class UsersManager
    {
        private List<User> users;
        private IUsers usersDB;
        private IAutoIncrement autoIncrement;

        public List<User> Users { get { return users; } private set { users = value; } }

        public UsersManager(IUsers usersDB, IAutoIncrement autoIncrement)
        {
            this.usersDB = usersDB;
            users = usersDB.ReadUsers();
            this.autoIncrement = autoIncrement;
        }

        public void GetUsers()
        {
            if (users != null)
            {
                users.Clear();
            }

            users = usersDB.ReadUsers();
        }

        public void AddUser(User user)
        {
            if (users.Any(x=>x.Account.ID==user.Account.ID))
            {
                throw new Exception("User already exists");
            }
            usersDB.AddUser(user);
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            if (!users.Any(x => x.Account.ID == user.Account.ID))
            {
                throw new Exception("User doesnt exist");
            }
            users[users.FindIndex(x => x.Account.ID == user.Account.ID)] = user; //replaces the user's infomation based on the ID
            usersDB.UpdateUser(user); 
            
        }

        public void DeleteUser(User user)
        {
            if (!users.Any(x => x.Account.ID == user.Account.ID))
            {
                throw new Exception("User doesnt exist");
            }

            users.Remove(user);
            usersDB.DeleteUser(user);
        }

        

        

        /// <summary>
        /// Retrieves the user by its login credentials. If they are invalid, user is null.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User RetrieveUserByCredentials(string username, string password)
        {
 
            return users.Find(x => x.Account.Username == username && x.Account.Password == password);
        }

        public bool TryLogin(string username, string password) //is this a good approach
        {
            foreach (User user in users)
            {
                if (user.Account.Username == username && user.Account.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckUsername(string username)
        {
            try
            {
                if (users.Any(u=> u.Account.Username==username))
                {
                    throw new Exception("Username already exists");
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool TryRegister(string username, string password)
        {
            try
            {
                CheckUsername(username);
                User newUser = new User(new Account(autoIncrement.GetID(), username, password), "Your first name", "Your last name", "youremail@gmail.com", "+123456789", "User");
                usersDB.AddUser(newUser);
                users.Add(newUser);
                return true;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public User GetUserByID(int id)
        {
            return users.First(x => x.Account.ID == id);
        }

        public User GetUserByUsername(string username)
        {
            if (!users.Any(x=>x.Account.Username==username))
            {
                throw new Exception("Please enter a valid username");
            }
            else
            {
                return users.First(x => x.Account.Username == username);
            }
        }


    }
}
