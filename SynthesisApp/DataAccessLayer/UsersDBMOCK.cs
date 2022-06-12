using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class UsersDBMOCK : IUsers, IAutoIncrement
    {
        public void AddUser(User user)
        {
            
        }

        public void DeleteUser(User user)
        {
            
        }

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public List<User> ReadUsers()
        {
            return new List<User>();
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}
