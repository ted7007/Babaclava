using Babaclava.Core.Books.Object;
using Babaclava.Core.Models;

namespace Babaclava.Core.Books;

public interface IBookRepository
{
    public Task<IEnumerable<BookWithUserResult?>> GetBooksWIthResultAsync(int count, Guid userId, CancellationToken cancellationToken);
    public Task<Book?> GetBookAsync(Guid bookId, CancellationToken cancellationToken);
}