using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tournament
    {
        //some are nullable
        private int id;
        private int minPlayers;
        private int maxPlayers;

        private string tournamentInfo;
        private string location;
        private string tournamentStatus;

        private List<User>? playersInTournament;
        private List<Match>? matches;

        private TournamentType tournamentType;
        private DateTime startDate;
        private DateTime endDate;
        //Add sport later. Currently we only work with badminton, but to make the application extendable
        //add sport and each sport will have its own match rules

        public int ID { get { return id; } }
        public List<User> PlayersInTournament { get { return playersInTournament; } } //only get if it is not null
        public List<Match> Matches { get { return matches; } }
        public TournamentType TournamentType { get { return tournamentType; } }
        public string TournamentInfo { get { return tournamentInfo; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }
        public int MinPlayers { get { return minPlayers; } }
        public int MaxPlayers { get { return maxPlayers; } }
        public string Location { get { return location; } }
        public string TournamentStatus { get { return tournamentStatus; } }


        //Not all params are needed(lists)
        public Tournament(int id, TournamentType tournamentType, string tournamentInfo, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, string tournamentStatus)
        {
            ValidateDates(startDate, endDate);
            ValidatePlayers(minPlayers, maxPlayers);
            ValidateType(tournamentType);
            this.id = id;
            this.tournamentType = tournamentType;
            this.tournamentInfo = tournamentInfo;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.location = location;
            this.tournamentStatus = "Open";

        }

        private void ValidateDates(DateTime startDate, DateTime endDate) //private
        {

            if (startDate.CompareTo(endDate)>0)
            {
                throw new Exception("Incorrect dates");
            }
        }
        private void ValidatePlayers(int minPlayers, int maxPlayers)
        {
            if (minPlayers<maxPlayers)
            {
                throw new Exception("Min players cannot be more than max players");
            }
        }

        private void ValidateType(TournamentType type) //make a unit test for every possible validation
        {
            if (!TournamentType.TournamentTypes.Contains(type));
            {
                throw new Exception("Invalid tournament type");
            }
        }

        public override string ToString()
        {
            return $"Tournament ID:{this.id} players: {minPlayers}/{maxPlayers}";
        }

    }
}
