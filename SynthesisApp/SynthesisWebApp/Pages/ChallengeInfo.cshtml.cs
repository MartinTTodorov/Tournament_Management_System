using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataAccessLayer;
using LogicLayer;
using Entities;
using SynthesisWebApp.DTOs;

namespace SynthesisWebApp.Pages
{
    public class ChallengeInfoModel : PageModel
    {

        private ChallengeManager challengeManager = new ChallengeManager(new ChallengesDB(), new ChallengesDB());


        public static UsersManager UsersManager { get; private set; }

        [BindProperty]
        int ID { get; set; }

        [BindProperty]
        public ChallengeResultsDTO ChallengeResults { get; set; }

        public static Challenge Challenge { get; set; }
        
        public void OnGet(int id)
        {
            Challenge = challengeManager.GetChallengeByID(id);
        }

        public IActionResult OnPostAcceptChallenge()
        {
            try
            {
                challengeManager.AcceptChallenge(Challenge);
                return new RedirectToPageResult("Challenges");

            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostDenyChallenge()
        {
            try
            {
                challengeManager.DenyChallenge(Challenge);
                return new RedirectToPageResult("Challenges");
                
            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return Page();
            }
        }

        public IActionResult OnPostSetResults()
        {
            try
            {
                challengeManager.SetResults(Challenge, ChallengeResults.ChallengerScore, ChallengeResults.OpponentScore);
                return new RedirectToPageResult("Challenges");
                

            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return Page();
            }
        }

    }
}
