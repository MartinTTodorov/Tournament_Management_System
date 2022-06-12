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
            return challenges.FindAll(x => x.OpponentID == id && (x.Status=="Awaiting" || x.Status=="Accepted" || x.Status=="Finished"));
        }

        
        public void ChallengeUser(int challengerID, int opponentID, DateTime date)
        {


            if (challengerID==opponentID)
            {
                throw new Exception("You can't challenge yourself");
            }
            Challenge challenge = new Challenge(autoIncrement.GetID(), challengerID, opponentID, date, new Match(0, 0, new Badminton()) , "Awaiting");
            challenges.Add(challenge);
            challengesDB.ChallengeUser(challenge);
        }

        public void SetResults(Challenge challenge, int player1Score, int player2Score)
        {
            if ((DateTime.Today - challenge.Date).Days==0)
            {
                challenge.Match.SetResults(player1Score, player2Score);
                challengesDB.SetResults(challenge);
            }
            else
            {
                throw new Exception($"You can't yet insert results");

            }
            
        }

        public Challenge GetChallengeByID(int id)
        {
            return challenges.First(x => x.ID == id);
        }

        public void AcceptChallenge(Challenge challenge)
        {
            challengesDB.AcceptChallenge(challenge);
        }

        

        public void DenyChallenge(Challenge challenge)
        {
            
            challengesDB.DenyChallenge(challenge);
        }
    }
}
