using BookShelf.Application.Services.Author;
using BookShelf.Models;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var authors = await _service.GetAll();

        if (authors.Count == 0)
            return NotFound();

        return Ok(authors);
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
    [Authorize]
    public async Task<ActionResult> CreateAuthor([FromBody] AuthorModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.CreateAuthor(model);

        return Ok(id);
    }
}