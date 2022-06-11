using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Account
    {
        private int id;
        private string username;
        private string password;

        public int ID { get { return id; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }

        public Account(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        

    }
}
