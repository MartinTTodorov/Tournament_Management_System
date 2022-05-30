using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entities
{
    public class User
    {
        private Account account;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string type;
        
        //private set with exceptions
        public Account Account { get { return account; } }
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } private set
            {
                Regex validateEmail = new Regex(@"^\\S+@\\S+\\.\\S+$");
                if (!validateEmail.IsMatch(email.ToLower().ToString()))
                {
                    throw new Exception("Invalid email");
                }
            }
        }
        public string Phone { get { return phone; } }
        public string Type { get { return type; } }

        public User(Account account, string firstName, string lastName, string email, string phone, string type)
        {
            this.account = account;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.type = type;
        }

    }
}
