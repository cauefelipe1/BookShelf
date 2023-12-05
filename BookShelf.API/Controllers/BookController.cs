using BookShelf.Application.Services.Book;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    private readonly IBookService _service;
    
    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet("{:id}")]
    public ActionResult GetBook(Guid id)
    {
        return Ok(Enumerable.Empty<BookModel>().ToList());
    }
    
    [HttpPost]
    public async Task<ActionResult> CreatePost([FromBody] BookModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.CreateBook(model);

        return Ok(id);
    }
}