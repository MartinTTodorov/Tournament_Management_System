using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class TournamentType
    {
        public abstract List<Match> CreateMatches(List<User> players);
    }
}
