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

    [HttpPost]
    public async Task<ActionResult> CreateAuthor([FromBody] AuthorModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.CreateAuthor(model);

        return Ok(id);
    }
}