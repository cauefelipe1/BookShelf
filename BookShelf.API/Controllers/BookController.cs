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

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBook(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var book = await _service.GetBook(id);

        if (book is null)
            return NotFound();

        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateBook([FromBody] BookModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.CreateBook(model);

        return Ok(id);
    }
    
    [HttpPut("{bookId}")]
    public async Task<ActionResult> UpdateBook(Guid bookId, [FromBody] BookModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var id = await _service.UpdateBook(bookId, model);

        if (!id)
            return BadRequest("Fail updating the book.");

        return NoContent();
    }
}