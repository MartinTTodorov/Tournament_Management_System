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
        
        public void SetMatchResults(Tournament tournament, Match match, int player1Score, int player2Score)
        {
            if (tournament.TournamentStatus==TournamentStatus.Scheduled)
            {
                match.SetResults(player1Score, player2Score);
                matchesDB.SetMatchResults(match);
            }
            else
            {
                throw new Exception($"You cant set results for this tournament. Status: {tournament.TournamentStatus}");
            }


        }
    }
}
