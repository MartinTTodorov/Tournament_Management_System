using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer;
using LogicLayer;
using Entities;
using SynthesisWebApp.DTOs;

namespace SynthesisWebApp.Pages
{
    [Authorize]
    public class TournamentPageModel : PageModel
    {
        private TournamentManager tournamentManager;
        private UsersManager userManager = new UsersManager(new UsersDB(), new UsersDB());
        private Tournament tournament;

        public TournamentPageModel(TournamentManager tournamentManager)
        {
            this.tournamentManager = tournamentManager;
        }

        public Tournament Tournament { get { return tournament; } private set { tournament = value; } }
        public List<Match> Matches { get; private set; }

        [BindProperty]
        public int ID { get; set; }

        public void OnGet(int id)
        {
            
            Tournament = tournamentManager.GetTournamentByID(id);
            try
            {
                tournamentManager.RetrieveMatches(Tournament);

            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }
            //Matches = tournamentManager.GetMatches(Tournament);
        }

        public IActionResult OnPost()
        {
            try
            {
                Tournament = tournamentManager.GetTournamentByID(ID);
                User user = userManager.GetUserByID(Convert.ToInt32(User.Claims.First(x => x.Type.Equals("ID")).Value));
                tournamentManager.AddPlayer(Tournament, user);

            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return Page();
            }
            return new RedirectToPageResult("Index");
        }
    }
}
