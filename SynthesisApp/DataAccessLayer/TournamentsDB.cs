using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class TournamentsDB : ITournaments<Tournament>
    {
        public void AddTournament(Tournament tournament)
        {
            throw new NotImplementedException();
            
        }

        public void DeleteTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public List<Tournament> ReadTournaments()
        {
            return null;
        }

        public void UpdateTournament(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
