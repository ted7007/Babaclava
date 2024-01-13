using Babaclava.Core.Books;
using Babaclava.Core.Books.Object;
using Babaclava.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Babaclava.Infrastructure.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BabaclavaDbContext _context;

    public BookRepository(BabaclavaDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<BookWithUserResult?>> GetBooksWIthResultAsync(int count, Guid userId, CancellationToken cancellationToken)
    {
        var books = _context.Books.Take(count);
        return await books.Select(b => new BookWithUserResult()
        {
            Book = b,
            UserResult = _context.UserResults
                .FirstOrDefault(ur => ur.UserId == userId && ur.BookId == b.Id)
        })
        .ToListAsync(cancellationToken);
    }

    public async Task<Book?> GetBookAsync(Guid bookId, CancellationToken cancellationToken)
    {
        return await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId, cancellationToken);
    }
}