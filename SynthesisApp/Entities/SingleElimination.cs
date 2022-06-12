using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SingleElimination : TournamentType
    {
        public override List<Match> CreateMatches(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "SingleElimination";
        }
    }
}
