using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUsers
    {
        public void AddUser(User user);
        public List<User> ReadUsers();
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
