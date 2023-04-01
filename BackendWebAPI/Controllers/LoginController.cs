using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly PixelWarsService _pixelwarsService;
        public LoginController(PixelWarsService pixelwarsService) =>
            _pixelwarsService = pixelwarsService;

        [Route("/login")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Route("/")]
        [Authorize]
        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }

        [Route("/CreateGrid")]
        [Authorize]
        [HttpGet]
        public IActionResult CreateGrid()
        {
            return View();
        }

        [Route("/InsertGrid")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PixelWarsCollection>> InsertGrid(string name, string size)
        {
            var insertValues = new PixelWarsCollection();
            insertValues.Name = name;
            insertValues.Size = size;

            await _pixelwarsService.InsertGridBynameAndSize(insertValues);

            var filter = await _pixelwarsService.GetByNameAsync(name);

            if (filter is null)
            {
                return NotFound();
            }

            return View();
        }

        [Route("/DeleteGrid")]
        [Authorize]
        [HttpGet]
        public IActionResult DeleteGrid()
        {
            return View();
        }

        [Route("/DeleteGridbyName")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PixelWarsCollection>> DeleteGridbyName(string name)
        {
            await _pixelwarsService.DeleteGridByName(name);

            var filter = await _pixelwarsService.GetByNameAsync(name);

            if (filter is null)
            {
                return View();
            }

            return NotFound();
        }
    }
}
