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
        private Challenge challenge;


        [BindProperty]
        int ID { get; set; }

        public Challenge Challenge { get { return challenge; } private set { challenge = value; } }
        
        public void OnGet(int id)
        {
            Challenge = challengeManager.GetChallengeByID(id);
        }


    }
}
