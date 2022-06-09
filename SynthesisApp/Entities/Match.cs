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
        //private SportType sport;
        //type that may be tournament match or challenge match

        public int ID { get { return id; } }
        public User Player1 { get { return player1; } }
        public User Player2 { get { return player2; } }
        public int Player1Score { get { return player1Score; } }
        public int Player2Score { get { return player2Score; } }
        //public SportType Sport { get { return sport; } }

        public Match(int id, User player1, User player2, int player1Score, int player2Score) //Validate when pulling matches from DB
        {
            //sport.ValidateResults(player1Score, player2Score);

            this.id = id;
            this.player1 = player1;
            this.player2 = player2;
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }
        

        /// <summary>
        /// Creates a new match, with scores being zero upon creation, as match has not yet concluded
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="player1Score"></param>
        /// <param name="player2Score"></param>
        public Match(User player1, User player2, int player1Score, int player2Score)
        {
            
            this.player1 = player1;
            this.player2 = player2;
            this.player1Score = player1Score;
            this.player2Score = player2Score;
        }

        public void SetResults(int p1Score, int p2Score)
        {
            //sport.ValidateResults(p1Score, p2Score);
            ValidateResults(p1Score, p2Score);
            this.player1Score = p1Score;
            this.player2Score = p2Score;
        }

        public void ValidateResults(int score1, int score2)
        {
            List<int> playerScores = new List<int>(new int[] { score1, score2 });
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
