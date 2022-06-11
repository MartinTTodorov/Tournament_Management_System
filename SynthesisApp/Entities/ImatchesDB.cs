using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Entities
{
    public interface ImatchesDB<T>
    {
        public void AddMatch(T match);
        public void SetMatchResults(T match);
        //public void CreateMatches(Tournament tournament);
    }
}
