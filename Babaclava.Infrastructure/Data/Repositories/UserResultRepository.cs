using Babaclava.Core.Books;
using Babaclava.Core.Models;

namespace Babaclava.Infrastructure.Data.Repositories;

public class UserResultRepository : IUserResultRepository
{
    private readonly BabaclavaDbContext _context;

    public UserResultRepository(BabaclavaDbContext context)
    {
        _context = context;
    }
    
    public async Task<UserResult?> GetUserResultAsync(Guid userId, Guid bookId, CancellationToken cancellationToken)
    {
        return _context.UserResults.FirstOrDefault(ur => ur.UserId == userId && ur.BookId == bookId);
    }

    public async Task AddResultAsync(UserResult result, CancellationToken cancellationToken)
    {
        await _context.UserResults.AddAsync(result, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateResultAsync(UserResult result, CancellationToken cancellationToken)
    {
        _context.UserResults.Update(result);
        await _context.SaveChangesAsync(cancellationToken);
    }
}