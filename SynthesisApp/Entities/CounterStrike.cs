using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CounterStrike : SportType
    {
        
        public override string ToString()
        {
            return "CounterStrike";
        }

        public override void ValidateResults(int score1, int score2)
        {
            if (score1 <= 0 || score2 <= 0)
            {
                throw new Exception("Scores can only be positive");
            }

            List<int> teamScores = new List<int>(new int[] { score1, score2 });


            int overtimes = 0; //determines how many overtimes are needed for these results
            if (score1>=15 && score2>=15)
            {
                if (score1+score2-30==6)
                {
                    overtimes = (score1 + score2 - 30) / 6;
                }
                else
                {
                    overtimes = (score1 + score2 - 30) / 6 + 1;

                }
            }
            int totalRounds = 30 + overtimes * 6; //total number of rounds with overtimes

            for (int i = 0; i < teamScores.Count; i++)
            {
                if ((teamScores[0] == totalRounds / 2 + 1) && (teamScores[1] < totalRounds / 2 && (teamScores[1] > totalRounds / 2 - 4)))
                {
                    break;
                }
                else
                {
                    if (i == 0)
                    {
                        teamScores.Reverse();
                    }
                    else
                    {
                        throw new Exception("Invalid results for counter strike");
                    }
                }
            }

            
        }
    }
}
