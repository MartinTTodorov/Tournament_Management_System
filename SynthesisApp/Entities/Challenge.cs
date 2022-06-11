using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Challenge
    {
        private int id;
        private int challengerID;
        private int opponentID;
        private string status;
        private Match match;

        public int ID { get { return id; } }
        public int ChallengerID { get { return challengerID; } }
        public int OpponentID { get { return opponentID; } }
        public string Status { get { return status; } }
        public Match Match { get { return match; } }

        public Challenge(int id, int challengerID, int opponentID, string status)
        {
            this.id = id;
            this.challengerID = challengerID;
            this.opponentID = opponentID;
            this.status = status;
        }


    }
}
