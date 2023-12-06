using BookShelf.Application.Services.Book;
using BookShelf.Data.Book;
using BookShelf.Models;
using FluentAssertions;
using Moq;

namespace BookShelf.Application.Tests.Book;

public class BookServiceTests
{
    private readonly Mock<IBookService> _bookServiceMock = new();
    
    [Fact]
    public async Task Create_Author()
    {
        var id = Guid.NewGuid();
        
        var book = new BookModel
        {
            Id = id,
            Isbn = "isbn",
            Title = "Book Title",
            PublishDate = DateTime.Today.AddYears(-5),
            Language = "English",
            Authors = new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Thomas",
                    LastName = "Edson"
                }
            }
        };
        
        var daoList = new List<BookDao>
        {
            new()
            {
                Id = id.ToString(),
                Isbn = book.Isbn,
                Title = book.Title,
                PublishDate = book.PublishDate,
                Language = book.Language,
                Auhtors = book.Authors.Select(a => a.Id.ToString()).ToList()!,
            }
        };

        var modelList = new List<BookModel>
        {
            book
        };
        
        // _bookServiceMock.Setup(x => x.GetBook(It.IsAny<AuthorDao>())).ReturnsAsync(id);
        // _authorRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(daoList);
        //
        // var service = new AuthorService(_authorRepositoryMock.Object);
        // var returnedId = await service.CreateAuthor(book);
        // var returnedAuthors = await service.GetAll();
        //
        // returnedId.Should().NotBeEmpty();
        // returnedId.Should().Be(id);
        //
        // returnedAuthors.Should().NotBeNull();
        // returnedAuthors.Should().HaveCount(modelList.Count);
        // returnedAuthors.Should().BeEquivalentTo(modelList);
    }
    
}