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
        private DateTime date;
        private Match match;

        public int ID { get { return id; } }
        public int ChallengerID { get { return challengerID; } }
        public int OpponentID { get { return opponentID; } }
        public string Status { get { return status; } }
        public DateTime Date { get { return date; } }
        public Match Match { get { return match; } }

        public Challenge(int id, int challengerID, int opponentID, DateTime date, Match match, string status)
        {
            ValidateDate(date);
            this.id = id;
            this.challengerID = challengerID;
            this.opponentID = opponentID;
            this.date = date;
            this.match = match;
            this.status = status;
        }

        public void ValidateDate(DateTime date)
        {
            if (date.Date<DateTime.Now.Date)
            {
                throw new Exception("You can't create a challenge before today");
            }
        }

       


    }
}
