using BookShelf.Application.Services.Author;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers;

[ApiController]
[Route("author")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    
    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAuthor(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var author = await _service.GetAuthor(id);

        if (author is null)
            return NotFound();

        return Ok(author);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateAuthor([FromBody] AuthorModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.CreateAuthor(model);

        return Ok(id);
    }
}