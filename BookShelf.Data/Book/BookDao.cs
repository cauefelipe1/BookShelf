namespace BookShelf.Data.Book;

public class BookDao
{
    public string Id { get; set; }

    public string Isbn { get; set; }

    public string Title { get; set; }

    public DateTime PublishDate { get; set; }

    public string Language { get; set; }
}