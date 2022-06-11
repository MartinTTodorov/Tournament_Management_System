using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer
{
    public class ChallengeManager
    {
        private List<Challenge> challenges;
        private IChallengesDB challengesDB;
        private IAutoIncrement autoIncrement;

        public List<Challenge> Challenges { get { return challenges; } }

        public ChallengeManager(IChallengesDB challengesDB, IAutoIncrement autoIncrement)
        {
            this.challengesDB = challengesDB;
            this.autoIncrement = autoIncrement;
            challenges = challengesDB.ReadChallenges();

        }

        

        public List<Challenge> GetUserChallenges(int id)
        {
            return challenges.FindAll(x => x.OpponentID == id);
        }
        public void ReadChallenges()
        {

        }
        public void ChallengeUser(int challengerID, int opponentID)
        {
            challenges.Add(new Challenge(autoIncrement.GetID(), challengerID, opponentID, "Awaiting"));
            challengesDB.ChallengeUser(challengerID, opponentID);
        }

        public void SetResults(Challenge challenge, int player1Score, int player2Score)
        {

        }

        public Challenge GetChallengeByID(int id)
        {
            return challenges.First(x => x.ID == id);
        }

        public void AcceptChallenge(Challenge challenge)
        {
            challengesDB.ChangeChallengeStatus(challenge, "Accepted");
        }

        public void UpdateStatus(Challenge challenge, string newStatus)
        {
            
        }

        public void DenyChallenge(Challenge challenge)
        {
            challengesDB.ChangeChallengeStatus(challenge, "Denied");
        }
    }
}
