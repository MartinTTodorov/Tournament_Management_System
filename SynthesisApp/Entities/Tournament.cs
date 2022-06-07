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

        private string title;
        private string tournamentInfo;
        private string location;
        private TournamentStatus tournamentStatus;

        private List<User>? playersInTournament;
        private List<Match>? matches;

        private TournamentType tournamentType;
        private DateTime startDate;
        private DateTime endDate;
        //Add sport later. Currently we only work with badminton, but to make the application extendable
        //add sport and each sport will have its own match rules

        public int ID { get { return id; } }
        public string Title { get { return title; } }
        public List<User> PlayersInTournament { get { return playersInTournament; } } //only get if it is not null
        public List<Match> Matches { get { return matches; } }
        public TournamentType TournamentType { get { return tournamentType; } }
        public string TournamentInfo { get { return tournamentInfo; } }
        public DateTime StartDate { get { return startDate; } }
        public DateTime EndDate { get { return endDate; } }
        public int MinPlayers { get { return minPlayers; } }
        public int MaxPlayers { get { return maxPlayers; } }
        public string Location { get { return location; } }
        public TournamentStatus TournamentStatus { get { return tournamentStatus; } }

        //Not all params are needed(lists)
        public Tournament(int id, TournamentType tournamentType, string title, string tournamentInfo, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, TournamentStatus tournamentStatus)
        {
            ValidateDates(startDate, endDate);
            ValidatePlayers(minPlayers, maxPlayers);
            //ValidateType(tournamentType);
            this.id = id;
            this.tournamentType = tournamentType;
            this.title = title;
            this.tournamentInfo = tournamentInfo;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.location = location;
            this.tournamentStatus = tournamentStatus;
            this.playersInTournament = new List<User>(); //ASK FOR THIS
        }

        public Tournament(string tournamentInfo, string title, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, TournamentType tournamentType)
        {
            ValidateDates(startDate, endDate);
            ValidatePlayers(minPlayers, maxPlayers);
            this.tournamentInfo = tournamentInfo;
            this.title = title;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.location = location;
            this.tournamentType=tournamentType;
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
            if (minPlayers>maxPlayers)
            {
                throw new Exception("Min players cannot be more than max players");
            }
        }
        //doesnt work
        private void ValidateType(TournamentType type) //make a unit test for every possible validation
        {
            if (!TournamentType.TournamentTypes.Contains(type));
            {
                throw new Exception("Invalid tournament type");
            }
        }
        public void ValidatePlayers(List<User> players)
        {
            if (players.Count==0)
            {
                players = new List<User>();
            }
            else
            {
                
            }
        }

        private void ValidateStatus()
        {
            if (true)
            {

            }
        }

        public void AssignMatches(List<Match> matches) //is this a bad approach. Also include validation
        {
            this.matches = matches;
        }

        public void AssignPlayers(List<User> players)
        {
            this.playersInTournament = players;
        }


        public void AddPlayer(User user)                                                                                             //think about when to retrieve this list. Maybe everytime or maybe not
        {
            if (playersInTournament.Count!=0 && playersInTournament.Any(p=>p==user))
            {
                throw new Exception("User has already entered this tournament");
            }
            else
            {
                playersInTournament.Add(user);
            }
        }
        public override string ToString()
        {
            if (playersInTournament==null)                                                                                          //is this a good validation
            {
                return $"Tournament ID:{this.id} players: 0/{maxPlayers}";
            }
            else
            {
                return $"Tournament ID:{this.id} players: {this.playersInTournament.Count}/{maxPlayers}";
            }
        }


    }
}
