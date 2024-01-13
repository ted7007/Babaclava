namespace Babaclava.Core.Books.Dto;

public class CatalogBookDto
{
    public Guid BookId { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public int PageSize { get; set; }

    public int PageNumber { get; set; }

    public int TotalPages { get; set; }
}