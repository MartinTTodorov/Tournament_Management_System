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


        public Account Account { get { return account; } }
        public string FirstName { get { return firstName; } 
            private set {
                Regex validateName = new Regex(@"[0-9]");
                if (!validateName.IsMatch(FirstName.ToLower().ToString()))
                {
                    throw new Exception("Name cannot contain numbers");
                }
                firstName = value;
            }
        }

        public string LastName { get { return lastName; }
            private set {
                Regex validateName = new Regex(@"[0-9]");
                if (!validateName.IsMatch(LastName.ToLower().ToString()))
                {
                    throw new Exception("Name cannot contain numbers");
                }
                lastName = value;
            }
        }
        public string Email { get { return email; } 
            private set
            {
                Regex validateEmail = new Regex(@"^\\S+@\\S+\\.\\S+$");
                if (!validateEmail.IsMatch(Email.ToLower().ToString()))
                {
                    throw new Exception("Invalid email");
                }
                email = value;
            }
        }
        public string Phone { get { return phone; } }
        public string Type { get { return type; } }

        public User(Account account, string firstName, string lastName, string email, string phone, string type)
        {
            ValidateName(firstName);
            ValidateName(lastName);
            ValidateEmail(email);
            this.account = account;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.type = type;
        }

        public void ValidateName(string name)
        {
            Regex validateName = new Regex(@"[0-9]");
            if (!validateName.IsMatch(name.ToLower().ToString()))
            {
                throw new Exception("Name cannot contain numbers");
            }
        }

        public void ValidateEmail(string email)
        {
            Regex validateEmail = new Regex(@"^\\S+@\\S+\\.\\S+$"); //([A-Za-z0-9])\w+@([A-Za-z0-9])\w+.\w
            if (!validateEmail.IsMatch(email.ToLower().ToString()))
            {
                throw new Exception("Invalid email");
            }
        }

    }
}
