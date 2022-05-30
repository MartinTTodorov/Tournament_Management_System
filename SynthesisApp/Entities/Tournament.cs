using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tournament
    {
        private int id;
        private List<User> playersInTournament;
        private List<Match> matches;
        TournamentType tournamentType;
        string tournamentInfo;
        DateTime startDate;
        DateTime endDate;
        int minPlayers;
        int maxPlayers;
        string location;

        public int Id { get { return id; } }
        public List<User> PlayersInTournament { get { return playersInTournament; } }
        public List<Match> Match { get { return matches; } }
        public TournamentType TournamentType { get { return tournamentType; } }
        public string TournamentInfo { get { return tournamentInfo; } }
        public DateTime StartDate { get { return startDate; }
            private set
            {
                //startDate cant be after endDate
                startDate = value; 
            } }
        public DateTime EndDate { get { return endDate; }
            private set
            {
                //endDate cant be before startDate
                endDate = value;
            } }

        public int MinPlayers { get { return minPlayers; } 
            private set 
            {
                //minPlayers cant be more than maxPlayers
            } }

        public int MaxPlayers { get { return maxPlayers; } }
        public string Location { get { return location; } }

        public void checkDate(DateTime startDate, DateTime endDate)
        {

            

            if (startDate.CompareTo(endDate)>0)
            {
                throw new Exception("Incorrect dates");
            }
        }
        public void checkPlayers()
        {

        }


    }
}
