using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class TournamentsDBMOCK : ITournaments, IAutoIncrement
    {
        public void AddPlayer(Tournament tournament, User player)
        {
            
        }

        public void AddTournament(Tournament tournament)
        {
            
        }

        public void CancelTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void CreateMatches(Tournament tournament)
        {
            
        }

        public void DeleteTournament(Tournament tournament)
        {
            
        }

        public void FinishTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public int GetID()
        {
            return 1;
        }

        public List<Tournament> ReadTournaments()
        {
            return new List<Tournament>();
        }

        public List<Match> RetrieveMatches(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void UpdateTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
