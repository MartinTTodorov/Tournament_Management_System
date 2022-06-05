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
        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }
        public string Email { get { return email; } }
        public string Phone { get { return phone; } }
        public string Type { get { return type; } }

        public User(Account account, string firstName, string lastName, string email, string phone, string type)
        {
            ValidateName(firstName);
            ValidateName(lastName);
            //ValidateEmail(email);
            this.account = account;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
            this.type = type;
        }

        public User(Account account)//Used when user registers. If he wishes, he can later set the rest of his information
        {
            this.account = account;
        }

        private void ValidateName(string name)
        {
            Regex validateName = new Regex(@"[0-9]");
            if (validateName.IsMatch(name.ToLower().ToString()))
            {
                throw new Exception("Name cannot contain numbers");
            }
        }
        
        private void ValidateEmail(string email)
        {
            Regex validateEmail = new Regex(@"([A-Za-z0-9])\w+@([A-Za-z0-9])\w+.\w"); 
            if (!validateEmail.IsMatch(email.ToLower().ToString()))
            {
                throw new Exception("Invalid email");
            }
        }

    }
}
