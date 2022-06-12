using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Volleyball : SportType
    {

        public override string ToString()
        {
            return "Volleyball";
        }

        public override void ValidateResults(int score1, int score2)
        {
            if (score1<=0 || score2<=0)
            {
                throw new Exception("Results can only be positive");
            }

            List<int> teamScores = new List<int>(new int[] { score1, score2 });

            for (int i = 0; i < teamScores.Count; i++)
            {

                if (teamScores[0] == 25 && (teamScores[0] - teamScores[1] >= 2) || teamScores[0]>25 && (teamScores[0]-teamScores[1]==2))
                {
                    break; 
                }
                else
                {
                    if (i==0)
                    {
                        teamScores.Reverse(); //checks for the other one

                    }
                    else
                    {
                        throw new Exception("Invalid scores for volleyball");
                    }
                }

            }

            
        }
    }
}
