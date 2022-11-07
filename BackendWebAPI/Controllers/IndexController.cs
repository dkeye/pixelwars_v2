using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReturnHTMLFromASPNETCoreWebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            var html = System.IO.File.ReadAllText(@"./index.html");

            return base.Content(html, "text/html");
        }




        /*
        [HttpGet]
        public ContentResult Index()
        {
            var html = System.IO.File.ReadAllText(@"D:\VisualStudioRepos\BackendWebAPI\static\index.html");            

            return base.Content(html, "text/html");
        }

        */


    }
}