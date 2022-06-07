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
        private List<Tournament> tournaments; //Should it be read only
        private ITournaments<Tournament> tournamentsDB;
        IAutoIncrement autoIncrement;

        public List<Tournament> Tournaments { get { return tournaments; } private set { tournaments = value; } }

        public TournamentManager(ITournaments<Tournament> tournamentsDB, IAutoIncrement autoIncrement)
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
            //creates a tournament with the appropriate ID and Status, as user doesnt set them
            Tournament newTournament = new Tournament(autoIncrement.GetID(), tournament.TournamentType, tournament.Title, tournament.TournamentInfo, tournament.StartDate, tournament.EndDate, tournament.MinPlayers, tournament.MaxPlayers, tournament.Location, TournamentStatus.Open);
            try
            {
                //check if a tournament with the same data exists (including ID). Maybe only check if the ID is the ssame, as the other data is not important
                if (!tournaments.Any(t => t == newTournament)) // do this for the rest too
                {
                    tournamentsDB.AddTournament(newTournament);
                    tournaments.Add(newTournament);
                }
                else
                {
                    throw new Exception("The tournament already exists");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            //check tournament status
            tournamentsDB.UpdateTournament(tournament);

        }

        public void DeleteTournament(Tournament tournament)
        {
            //check if the tournament exists in the list and then delete it
            tournamentsDB.DeleteTournament(tournament);
            tournaments.Remove(tournament);
        }

        public void AddPlayer(Tournament tournament, User player)
        {

            tournaments.First(x=>x.ID==tournament.ID).AddPlayer(player);
            tournamentsDB.AddPlayer(tournament, player);
        }

        public Tournament GetTournamentByID(int id)
        {
            return tournaments.First(x => x.ID == id);
        }

        /// <summary>
        /// Generates the matches for the tournament and uploads them to the database. 
        /// </summary>
        /// <param name="tournament"></param>
        public void CreateMatches(Tournament tournament) //make it a bool and if it returns true, then dislay a messagebox that it was successful  
        {

            if (tournament.TournamentStatus != TournamentStatus.Open)
            {
                throw new Exception($"Schedule can be generated only if the tournament is open. Current status: {tournament.TournamentStatus}");
            }

            if ((tournament.StartDate-DateTime.Now).Days>7)
            {
                throw new Exception("Tournament can only be scheduled 7 days prior to the start date");
            }

            //tournament.TournamentType.CreateMatches(tournament.PlayersInTournament);
            tournament.AssignMatches(tournament.TournamentType.CreateMatches(tournament.PlayersInTournament));
            tournamentsDB.CreateMatches(tournament);

        }

        
    }
}
