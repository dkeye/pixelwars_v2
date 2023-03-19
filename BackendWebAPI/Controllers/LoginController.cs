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

 
    }
}
