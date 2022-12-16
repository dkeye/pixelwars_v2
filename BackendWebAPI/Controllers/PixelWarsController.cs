using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers 
{

    [ApiController]
    [Route($"[controller]")]

    public class PixelWarsController : ControllerBase
    {
            
        private readonly PixelWarsService _pixelwarsService;

        public PixelWarsController(PixelWarsService pixelwarsService) =>
            _pixelwarsService = pixelwarsService;

        [HttpGet]
        public async Task<List<PixelWarsCollection>> Get() => await _pixelwarsService.GetAsync();

        [HttpGet]
        [Route("/grid/{index}/get/full")]
        public ActionResult GetFullGrid(int index)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/grid/{index}/get/square/{X}/{Y}")]
        public ActionResult GetCoordinateGrid(int index, int X, int Y)
        {
            return Ok();
        }

        [HttpPost]
        [Route("/grid/{index}/set/square")]
        public ActionResult SetGrid(int index)
        {
            return Ok();
        }
    }
}


