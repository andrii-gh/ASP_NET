using _02.DTOs;
using _02.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _authorService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateAuthorWithFileDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _authorService.CreateAsync(dto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateAuthorWithFileDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _authorService.UpdateAsync(id, dto);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _authorService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}