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
    public class LoginModel : PageModel
    {
        private UsersManager userManager = new UsersManager(new UsersDB(), new UsersDB());

        [BindProperty]
        public UserDTO UserLogin { get; set; }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Login();
            }
            return new PageResult();
        }


        private IActionResult Login()
        {
            if (userManager.TryLogin(UserLogin.UserName, UserLogin.Password))
            {
                SetupSessionCookie();
                return new RedirectToPageResult("Index");
            }
            else
            {
                ViewData["Error"] = "Wrong credentials";
                return Page();
            }
        }


        private void SetupSessionCookie()
        {
            User user = userManager.RetrieveUserByCredentials(UserLogin.UserName, UserLogin.Password);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            claims.Add(new Claim("ID", user.Account.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity));
        }
    }
}
