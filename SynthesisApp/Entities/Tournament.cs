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
        private TournamentType tournamentType;
        private string tournamentInfo;
        private DateTime startDate;
        private DateTime endDate;
        private int minPlayers;
        private int maxPlayers;
        private string location;
        private string tournamentStatus;

        public int Id { get { return id; } }
        public List<User> PlayersInTournament { get { return playersInTournament; } }
        public List<Match> Match { get { return matches; } }
        public TournamentType TournamentType { get { return tournamentType; } }
        public string TournamentInfo { get { return tournamentInfo; } }
        public DateTime StartDate { get { return startDate; }
            private set
            {
                if (startDate.CompareTo(endDate) > 0)
                {
                    throw new Exception("Incorrect dates");
                }
                startDate = value; 
            } }
        public DateTime EndDate { get { return endDate; }
            private set
            {
                if (startDate.CompareTo(endDate) < 0)
                {
                    throw new Exception("Incorrect dates");
                }
                endDate = value;
            } }

        public int MinPlayers { get { return minPlayers; } 
            private set 
            {
                if (MinPlayers>maxPlayers)
                {
                    throw new Exception("Min players cannot be more than max players");
                }
            } }

        public int MaxPlayers { get { return maxPlayers; } }
        public string Location { get { return location; } }
        public string TournamentStatus { get { return tournamentStatus; } }


        //Not all params are needed(lists)
        public Tournament(int id, List<User> playersInTournament, List<Match> matches, TournamentType tournamentType, string tournamentInfo, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, string tournamentStatus)
        {
            ValidateDates(startDate, endDate);
            ValidatePlayers(minPlayers, maxPlayers);
            this.id = id;
            //this.playersInTournament = playersInTournament;
            this.matches = matches;
            this.tournamentType = tournamentType;
            this.tournamentInfo = tournamentInfo;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.location = location;
            this.tournamentStatus = tournamentStatus; //open

        }

        public void ValidateDates(DateTime startDate, DateTime endDate) //private
        {

            

            if (startDate.CompareTo(endDate)>0)
            {
                throw new Exception("Incorrect dates");
            }
        }
        public void ValidatePlayers(int minPlayers, int maxPlayers)
        {
            if (minPlayers<maxPlayers)
            {
                throw new Exception("Min players cannot be more than max players");
            }
        }


    }
}
