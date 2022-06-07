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
        /// <summary>
        /// Inserts matches into the database
        /// </summary>
        /// <param name="match"></param>
        public void AddMatch(Match match)
        {
            matchesDB.AddMatch(match);
        }

        public void UpdateMatch(Match match)
        {
            matchesDB.UpdateMatch(match);
        }

        public void CreateMatches(Tournament tournament)
        {
            tournament.TournamentType.CreateMatches(tournament.PlayersInTournament);
            
        }
    }
}
