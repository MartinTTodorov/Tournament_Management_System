using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IAccounts<T>
    {
        public void AddAccount(T account);
        public List<T> ReadAccounts();
        public void UpdateAccount(T account);
        public void DeleteAccount(T account);
    }
}
