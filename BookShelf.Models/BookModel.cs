namespace BookShelf.Models;

public class BookModel
{
    public Guid Id { get; set; }

    public string Isbn { get; set; }

    public string Title { get; set; }

    public DateTime PublishData { get; set; }

    public string Language { get; set; }

    public List<AuthorModel> Authors { get; set; }
}