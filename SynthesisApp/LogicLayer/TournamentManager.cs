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

        public List<Tournament> Tournaments { get { return tournaments; } private set { tournaments = value; } }

        public TournamentManager(ITournaments<Tournament> tournamentsDB)
        {
            this.tournamentsDB = tournamentsDB;
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
            try
            {
                tournamentsDB.AddTournament(tournament);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            tournaments.Add(tournament);
        }

        public void UpdateTournament(Tournament tournament)
        {
            tournamentsDB.UpdateTournament(tournament);

        }

        public void DeleteTournament(Tournament tournament)
        {
            tournamentsDB.DeleteTournament(tournament);
            tournaments.Remove(tournament);
        }
        
    }
}
