using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DoubleRoundRobin : TournamentType
    {
        public override List<Match> CreateMatches(List<User> players)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "DoubleRoundRobin";
        }
    }
}
