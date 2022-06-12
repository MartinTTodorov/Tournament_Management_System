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
        private SportType sport;
        private DateTime startDate;
        private DateTime endDate;
        

        public int ID { get { return id; } }
        public string Title { get { return title; } }
        public SportType Sport { get { return sport; } }
        public List<User> PlayersInTournament { get { return playersInTournament; } } 
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
        public Tournament(int id, TournamentType tournamentType, string title, string tournamentInfo, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, SportType sport, TournamentStatus tournamentStatus)
        {
            ValidateDates(startDate, endDate);
            ValidatePlayers(minPlayers, maxPlayers);
            this.id = id;
            this.tournamentType = tournamentType;
            this.title = title;
            this.tournamentInfo = tournamentInfo;
            this.startDate = startDate;
            this.endDate = endDate;
            this.minPlayers = minPlayers;
            this.maxPlayers = maxPlayers;
            this.location = location;
            this.sport = sport;
            this.tournamentStatus = tournamentStatus;
            this.playersInTournament = new List<User>();
        }

        public Tournament(string tournamentInfo, string title, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, TournamentType tournamentType, SportType sport)
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
            this.sport = sport;
        }

        private void ValidateDates(DateTime startDate, DateTime endDate)
        {

            if (startDate.CompareTo(endDate)>0)
            {
                throw new Exception("Incorrect dates");
            }
        }
        private void ValidatePlayers(int minPlayers, int maxPlayers)
        {
            if (minPlayers==null || maxPlayers == null)
            {
                throw new Exception("Please insert number of players");
            }

            if (minPlayers<=0 || maxPlayers<=0)
            {
                throw new Exception("Min or max players cant be negative");
            }

            if (minPlayers>maxPlayers)
            {
                throw new Exception("Min players cannot be more than max players");
            }
        }
        

        public void AssignMatches(List<Match> matches)
        {
            this.matches = matches;
        }

        public void AssignPlayers(List<User> players)
        {
            this.playersInTournament = players;
        }


        public void AddPlayer(User user)                                                                                            
        {
            if (playersInTournament.Count==maxPlayers)
            {
                throw new Exception("This tournament is already full");
            }

            if (playersInTournament.Count!=0 && playersInTournament.Any(p=>p.Account.ID==user.Account.ID))
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
            if (playersInTournament==null)                                                                                         
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
