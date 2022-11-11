using BackendWebAPI.Models;
using BackendWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PixelWarsController : ControllerBase
    {
        private readonly PixelWarsService _pixelwarsService;

        public PixelWarsController(PixelWarsService pixelwarsservice) =>
            _pixelwarsService = pixelwarsservice;

        [HttpGet]
        public async Task<List<Test>> Get() =>
            await _pixelwarsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Test>> Get(string id)
        {
            var test = await _pixelwarsService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Test newTest)
        {
            await _pixelwarsService.CreateAsync(newTest);

            return CreatedAtAction(nameof(Get), new { id = newTest.Id }, newTest);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Test updatedTest)
        {
            var book = await _pixelwarsService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedTest.Id = book.Id;

            await _pixelwarsService.UpdateAsync(id, updatedTest);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var test = await _pixelwarsService.GetAsync(id);

            if (test is null)
            {
                return NotFound();
            }

            await _pixelwarsService.RemoveAsync(id);

            return NoContent();
        }
    }
}
