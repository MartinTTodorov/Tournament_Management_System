using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IChallengesDB
    {
        public void ChallengeUser(Challenge challenge);
        public void AcceptChallenge(Challenge challenge);
        public void DenyChallenge(Challenge challenge);
        public void SetResults(Challenge challenge);
        public List<Challenge> ReadChallenges();
    }
}
