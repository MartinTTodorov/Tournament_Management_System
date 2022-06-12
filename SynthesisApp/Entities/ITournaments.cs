using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITournaments
    {
        public void AddTournament(Tournament tournament);
        public List<Tournament> ReadTournaments();
        public void UpdateTournament(Tournament tournament);
        public void DeleteTournament(Tournament tournament);
        public void AddPlayer(Tournament tournament, User player);
        public void CreateMatches(Tournament tournament);
        public void CancelTournament(Tournament tournament);
        public List<Match> RetrieveMatches(Tournament tournament);
        public void FinishTournament(Tournament tournament);
    }
}
