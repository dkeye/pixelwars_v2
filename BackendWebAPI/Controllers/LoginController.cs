using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers
{
    public class LoginController : Controller
    {
        [Route("/login")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("/")]
        [Authorize]
        public IActionResult Main()
        {
            return View();
        }

        [Route("/CreateGrid")]
        [Authorize]
        public IActionResult CreateGrid()
        {
            return View();
        }

 
    }
}
