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
        [Route("/grid/{Name}/get/full")]
        public async Task<ActionResult<PixelWarsCollection>> GetFullGrid(string Name)
        {
            var filter = await _pixelwarsService.GetByNameAsync(Name);

            if (filter is null)
            {
                return NotFound();
            }

            return filter;
        }
        
        [HttpGet]
        [Route("/grid/{Name}/get/square")]
        public async Task<ActionResult<Square>> GetSquareFromGrid(string Name, int x, int y)
        {
            var filter = await _pixelwarsService.GetSquareAsync(Name, x, y);

            if (filter is null)
            {
                return NotFound();
            }

            return filter;
        }
        
        [HttpPost]
        [Route("/grid/{Name}/set/square/{x}/{y}/{color}")]
        public async Task<ActionResult<Square>> SetSquareToGrid(string Name, int x, int y, string color)
        {
            await _pixelwarsService.UpdateSquareColor(Name,x,y,color);

            var filter = await _pixelwarsService.GetSquareAsync(Name, x, y);

            if (filter is null)
            {
                return NotFound();
            }     

            return filter;
        }
    }
}


