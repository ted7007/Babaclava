namespace Babaclava.Core.Models;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string ImageUrl { get; set; }

    public int Size { get; set; }

    public string TextPath { get; set; }
}