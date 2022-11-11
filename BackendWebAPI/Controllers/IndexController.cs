using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReturnHTMLFromASPNETCoreWebAPI.Controllers
{
    [Route("Index")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            var html = System.IO.File.ReadAllText(@$"{Directory.GetParent(Directory.GetCurrentDirectory())}\static\index.html");

            return base.Content(html, "text/html");
        }
    }
}