using System.ComponentModel.DataAnnotations;
using BookShelf.Application.Services.Book;
using BookShelf.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<ActionResult> CreateBook([FromBody] BookModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        try
        {
            var id = await _service.CreateBook(model);

            return Ok(id);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut("{bookId}")]
    [Authorize]
    public async Task<ActionResult> UpdateBook(Guid bookId, [FromBody] BookModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        try
        {
            bool updated = await _service.UpdateBook(bookId, model);
            
            if (!updated)
                return BadRequest("Fail updating the book.");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }

        return NoContent();
    }
    
    [HttpDelete("{bookId}")]
    [Authorize]
    public async Task<ActionResult> DeleteBook(Guid bookId)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        var deleted = await _service.DeleteBook(bookId);

        if (!deleted)
            return BadRequest("Fail deleting the book.");

        return NoContent();
    }
}