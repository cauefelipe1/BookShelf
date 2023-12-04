using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers;

[ApiController]
[Route("book")]
public class BookController : ControllerBase
{
    public BookController()
    {
    }

    [HttpGet]
    public IList<BookModel> Get()
    {
        return Enumerable.Empty<BookModel>().ToList();
    }
}