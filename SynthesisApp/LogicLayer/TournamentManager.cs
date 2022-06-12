using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer
{
    public class TournamentManager
    {
        private List<Tournament> tournaments;
        private ITournaments tournamentsDB;
        IAutoIncrement autoIncrement;

        public IList<Tournament> Tournaments { get { return tournaments.AsReadOnly(); } private set { tournaments = value.ToList(); } }

        public TournamentManager(ITournaments tournamentsDB, IAutoIncrement autoIncrement)
        {
            this.tournamentsDB = tournamentsDB;
            this.autoIncrement = autoIncrement;
            tournaments = tournamentsDB.ReadTournaments();
        }

        public void GetTournaments()
        {
            if (tournaments != null)
            {
                tournaments.Clear();
            }

            tournaments = tournamentsDB.ReadTournaments();
        }



        public void AddTournament(Tournament tournament)
        {
            if ((tournament.StartDate-DateTime.Now).Days<6)
            {
                throw new Exception("Tournament can only be created at least a week after the current date");
            }

            //creates a tournament with the appropriate ID and Status, as user doesnt set them
            Tournament newTournament = new Tournament(autoIncrement.GetID(), tournament.TournamentType, tournament.Title, tournament.TournamentInfo, tournament.StartDate, tournament.EndDate, tournament.MinPlayers, tournament.MaxPlayers, tournament.Location, tournament.Sport, TournamentStatus.Open);
            
                //check if a tournament with the same data exists (ID)
            if (!tournaments.Any(t => t.ID == newTournament.ID)) 
            {
                tournamentsDB.AddTournament(newTournament);
                tournaments.Add(newTournament);
            }
            else
            {
                throw new Exception("The tournament already exists");
            }
            
        }

        

        public void DeleteTournament(Tournament tournament)
        {
            //check if the tournament exists in the list and then delete it
            if (!tournaments.Any(x => x.ID == tournament.ID))
            {
                throw new Exception("The tournament does not exist");
            }

            if (tournament.TournamentStatus==TournamentStatus.Open && tournament.PlayersInTournament.Count==0)
            {
                tournamentsDB.DeleteTournament(tournament);
                tournaments.Remove(tournaments.First(x=>x.ID==tournament.ID));
            }
            else
            {
                throw new Exception($"You can't delete a tournament that is not open or has players that have entered. Current tournament is {tournament.TournamentStatus} and has {tournament.PlayersInTournament.Count} players. You can try to cancel the tournament");
            }
        }

        public void AddPlayer(Tournament tournament, User player)
        {
            if (tournament.TournamentStatus!=TournamentStatus.Open)
            {
                throw new Exception($"You cant join a tournament that is not open. This tournament's status is: {tournament.TournamentStatus}");
            }

            if (tournament.PlayersInTournament.Any(x=>x.Account.ID==player.Account.ID))
            {
                throw new Exception("You have already joined this tournament");
            }
            tournament.AddPlayer(player);
            tournamentsDB.AddPlayer(tournament, player);
        }

        public bool CheckForFinish(Tournament tournament)
        {
            if (tournament.Matches.TrueForAll(x=>x.Player1Score!=0))
            {
                Tournament newTournament = new Tournament(tournament.ID, tournament.TournamentType, tournament.Title, tournament.TournamentInfo, tournament.StartDate, tournament.EndDate, tournament.MinPlayers, tournament.MaxPlayers, tournament.Location, tournament.Sport, TournamentStatus.Finished);
                tournaments.Remove(tournament);
                tournaments.Add(newTournament);
                tournamentsDB.FinishTournament(tournament);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Tournament GetTournamentByID(int id)
        {
            if (tournaments.Any(x=>x.ID==id))
            {
                return tournaments.First(x => x.ID == id);
            }
            else
            {
                throw new Exception($"Tournament with ID {id} doesn't exist");
            }

        }

        /// <summary>
        /// Generates the matches for the tournament and uploads them to the database. 
        /// </summary>
        /// <param name="tournament"></param>
        public void CreateMatches(Tournament tournament)
        {


            if (tournament.TournamentStatus != TournamentStatus.Open)
            {
                throw new Exception($"Schedule can be generated only if the tournament is open. Current status: {tournament.TournamentStatus}");
            }

            if ((tournament.StartDate-DateTime.Now).Days>7)
            {
                throw new Exception("Tournament can only be scheduled 7 days prior to the start date");
            }

            if (tournament.PlayersInTournament.Count<tournament.MinPlayers)
            {
                CancellTournament(tournament);

                throw new Exception($"The tournament did not reach the minimum number of players when it was time to create the matches, so tournament with ID {tournament.ID} was cancelled");
            }
            tournament.AssignMatches(tournament.TournamentType.CreateMatches(tournament));
            tournamentsDB.CreateMatches(tournament);

        }

        private void CancellTournament(Tournament tournament)
        {

            Tournament newTournament = new Tournament(tournament.ID, tournament.TournamentType, tournament.Title, tournament.TournamentInfo, tournament.StartDate, tournament.EndDate, tournament.MinPlayers, tournament.MaxPlayers, tournament.Location, tournament.Sport, TournamentStatus.Cancelled);
            tournaments.Remove(tournament);
            tournaments.Add(newTournament);
            tournamentsDB.CancelTournament(tournament);
        }

        public List<Match> GetMatches(Tournament tournament)
        {
            return tournamentsDB.RetrieveMatches(tournament);
        }

        public void RetrieveMatches(Tournament tournament)
        {
            if (tournament.TournamentStatus==TournamentStatus.Open || tournament.TournamentStatus==TournamentStatus.Cancelled)
            {
                throw new Exception($"You can see the matches for scheduled or concluded tournaments. This tournament's status: {tournament.TournamentStatus}");
            }

            tournament.AssignMatches(tournamentsDB.RetrieveMatches(tournament));
        }

        
    }
}
