using System;
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
        private IUsers<User> usersDB;
        private IAutoIncrement autoIncrement;

        public List<User> Users { get { return users; } private set { users = value; } }

        public UsersManager(IUsers<User> usersDB, IAutoIncrement autoIncrement)
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

            users = usersDB.ReadUsers(); //Should i use the list or the property Users
        }

        public void AddUser(User user)
        {
            usersDB.AddUser(user);
            users.Add(user);
        }

        public void UpdateUser(User user)
        {
            usersDB.UpdateUser(user); 
            
        }

        public void DeleteUser(User user)
        {
            usersDB.DeleteUser(user);
            users.Remove(user);
        }

        public User RetrieveUserByID(int id)
        {
            return users?.Find(x=>x.Account.ID==id); //Question mark
        }

        public User RetrieveUserByAccount()
        {
            return null;
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

        public bool TryLogin(string username, string password)
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


    }
}
