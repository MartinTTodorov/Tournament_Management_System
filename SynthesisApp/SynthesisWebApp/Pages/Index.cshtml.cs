using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicLayer;
using Entities;
using DataAccessLayer;

namespace SynthesisWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private TournamentManager tournamentManager = new TournamentManager(new TournamentsDB(), new TournamentsDB());
        private List<Tournament> tournaments;

        public List<Tournament> Tournaments { get { return tournaments; } private set { tournaments = value; } }
        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Tournaments = tournamentManager.Tournaments.ToList();
        }
    }
}