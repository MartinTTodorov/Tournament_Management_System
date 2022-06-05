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
    public class RegisterPageModel : PageModel
    {
        private UsersManager userManager = new UsersManager(new UsersDB(), new UsersDB());

        [BindProperty]
        public UserDTO UserRegister { get; set; }


        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Register();
            }
            return new PageResult();
        }


        private IActionResult Register()
        {
            if (userManager.TryRegister(UserRegister.UserName, UserRegister.Password))
            {
                SetupSessionCookie();
                return new RedirectToPageResult("Index");
            }
            else
            {
                return new RedirectToPageResult("Error");
            }
        }


        private void SetupSessionCookie()
        {

            User user = userManager.RetrieveUserByCredentials(UserRegister.UserName, UserRegister.Password);
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
