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
    public class ChallengesModel : PageModel
    {

        private UsersManager usersManager = new UsersManager(new UsersDB(), new UsersDB());
        private ChallengeManager challengeManager = new ChallengeManager(new ChallengesDB(), new ChallengesDB());
  

        public static List<Challenge> UserChallenges { get; private set; }
        public static string Challenger { get; private set; }

        [BindProperty]
        public ChallengeDTO ChallengeData { get; set; }

        public void OnGet()
        {
            UserChallenges = challengeManager.GetUserChallenges(Convert.ToInt32(User.Claims.First(x=>x.Type.Equals("ID")).Value));
            
            
        }

        public IActionResult OnPost()
        {
            try
            {
                User opponent = usersManager.GetUserByUsername(ChallengeData.UserName);
                challengeManager.ChallengeUser(Convert.ToInt32(User.Claims.First(x => x.Type.Equals("ID")).Value), opponent.Account.ID, Convert.ToDateTime(ChallengeData.Date));

            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;

            }
                return Page();
        }
    }
}
