using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IChallengesDB
    {
        public void ChallengeUser(int challengerID, int opponentID);
        public void ChangeChallengeStatus(Challenge challenge, string status);
        public List<Challenge> ReadChallenges();
    }
}
