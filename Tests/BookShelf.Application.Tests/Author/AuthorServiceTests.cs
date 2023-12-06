using BookShelf.Application.Services.Author;
using BookShelf.Data.Author;
using BookShelf.Models;
using FluentAssertions;
using Moq;

namespace BookShelf.Application.Tests.Author;

public class AuthorServiceTests
{
    private readonly Mock<IAuthorRepository> _authorRepositoryMock = new();
    
    [Fact]
    public async Task Create_Author()
    {
        var id = Guid.NewGuid();
        
        var author = new AuthorModel
        {
            Id = id,
            FirstName = "New",
            LastName = "Author"
        };
        
        var daoList = new List<AuthorDao>
        {
            new()
            {
                Id = id.ToString(),
                FirstName = author.FirstName,
                LastName = author.LastName
            }
        };

        var modelList = new List<AuthorModel>
        {
            author
        };
        
        _authorRepositoryMock.Setup(x => x.CreateAuthor(It.IsAny<AuthorDao>())).ReturnsAsync(id);
        _authorRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(daoList);
        
        var service = new AuthorService(_authorRepositoryMock.Object);
        var returnedId = await service.CreateAuthor(author);
        var returnedAuthors = await service.GetAll();

        returnedId.Should().NotBeEmpty();
        returnedId.Should().Be(id);

        returnedAuthors.Should().NotBeNull();
        returnedAuthors.Should().HaveCount(modelList.Count);
        returnedAuthors.Should().BeEquivalentTo(modelList);
    }
    
    [Fact]
    public async Task Get_Author_By_Book()
    {
        var id = Guid.NewGuid();
        
        var author = new AuthorModel
        {
            Id = id,
            FirstName = "New",
            LastName = "Author"
        };
        
        var daoList = new List<AuthorDao>
        {
            new()
            {
                Id = id.ToString(),
                FirstName = author.FirstName,
                LastName = author.LastName
            }
        };

        var modelList = new List<AuthorModel>
        {
            author
        };
        
        _authorRepositoryMock.Setup(x => x.GetAuthorsByBook(It.IsAny<Guid>())).ReturnsAsync(daoList);
        
        var service = new AuthorService(_authorRepositoryMock.Object);
        var returnedAuthors = await service.GetAuthorsByBook(It.IsAny<Guid>());

        returnedAuthors.Should().NotBeNull();
        returnedAuthors.Should().HaveCount(modelList.Count);
        returnedAuthors.Should().BeEquivalentTo(modelList);
    }
}