using Babaclava.Core.Models;

namespace Babaclava.Core.Books;

public interface IUserResultRepository
{
    public Task<UserResult?> GetUserResultAsync(Guid userId, Guid bookId, CancellationToken cancellationToken);
    
    public Task AddResultAsync(UserResult result, CancellationToken cancellationToken); //todo: unit of work

    public Task UpdateResultAsync(UserResult result, CancellationToken cancellationToken);
}