using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer
{
    public class MatchManager
    {
        private ImatchesDB<Match> matchesDB;

        public MatchManager(ImatchesDB<Match> matchesDB)
        {
            this.matchesDB = matchesDB;
        }
        public void AddMatch(Match match)
        {
            matchesDB.AddMatch(match);
        }

        public void UpdateMatch(Match match)
        {
            matchesDB.UpdateMatch(match);
        }
    }
}
