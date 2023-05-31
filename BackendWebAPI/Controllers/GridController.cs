using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers
{
    public class GridController : Controller
    {
        private readonly PixelWarsService _pixelwarsService;
        public GridController(PixelWarsService pixelwarsService) => _pixelwarsService = pixelwarsService;

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
        public IActionResult InsertGrid()
        {
            return View();
        }

        [Route("/InsertGrid")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PixelWarsGrid>> InsertGridByName(string name, uint x, uint y)
        {
            await _pixelwarsService.GenerateGrid(name, x, y);

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
        public async Task<ActionResult<PixelWarsGrid>> DeleteGridbyName(string name)
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
