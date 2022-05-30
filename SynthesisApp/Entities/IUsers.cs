using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IUsers<T>
    {
        public void AddUser(T user);
        public List<T> ReadUsers();
        public void UpdateUser(T user);
        public void DeleteUser(T user);
    }
}
