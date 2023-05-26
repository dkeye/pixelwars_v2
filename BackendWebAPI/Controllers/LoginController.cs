using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers
{
    public class LoginController : Controller
    {
       /* private readonly SignInManager<Person> _signInManager;
        public LoginController(SignInManager<Person> signInManager)
        {
            _signInManager = signInManager;
        }*/

        [Route("/login")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

       /* [Route("/logout")]
        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/login");
        }*/
    }
}
