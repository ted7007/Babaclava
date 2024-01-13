using Babaclava.Core.Models;

namespace Babaclava.Core.Books.Object;

public class BookWithUserResult
{
    public Book Book { get; set; }

    public UserResult? UserResult { get; set; }
}