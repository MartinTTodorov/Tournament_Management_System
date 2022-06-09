using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Badminton : SportType
    {

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void ValidateResults(int score1, int score2)
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
