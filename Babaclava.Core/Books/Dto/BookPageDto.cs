namespace Babaclava.Core.Books.Dto;

public class BookPageDto
{
    public string Text { get; set; }

    public int PageSize { get; set; }

    public bool HasNextPage { get; set; }

    public bool HasPreviousPage { get; set; }
}