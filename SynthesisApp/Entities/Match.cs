using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Match
    {
        private int id;
        private User player1;
        private User player2;
        private int player1Score;
        private int player2Score;

        public int ID { get { return id; } }
        public User Player1 { get { return player1; } }
        public User Player2 { get { return player2; } }
        public int Player1Score { get { return player1Score; } }
        public int Player2Score { get { return player2Score; } }

        public Match(int id, User player1, User player2, int player1Score, int player2Score)
        {
            ValidateResults();
            this.id=id;
            this.player1=player1;
            this.player2=player2;
            this.player1Score=player1Score;
            this.player2Score=player2Score;
        }

        public Match(User player1, User player2, int player1Score, int player2Score)
        {
            ValidateResults();
            this.player1 = player1;
            this.player2 = player2;
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }

        public void ValidateResults()
        {
            ValidateResults();
            List<int> playerScores = new List<int>(new int[] { player1Score, player2Score });
            for (int i = 0; i < playerScores.Count; i++)
            {
                if ((playerScores[0] >= 21 && playerScores[0] <= 29 && playerScores[0] - playerScores[1] >= 2) || (playerScores[0] == 29 && playerScores[1] == 30))
                {
                    playerScores.Reverse();
                }
                else
                {
                    throw new Exception("Input scores are invalid");
                }

            }
        }
    }
}
