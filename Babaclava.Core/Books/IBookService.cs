using Babaclava.Core.Books.Dto;
using FluentResults;

namespace Babaclava.Core.Books;

public interface IBookService
{
    public Task<Result<IEnumerable<CatalogBookDto>>> GetCatalogAsync(int bookCount, int pageSize, CancellationToken cancellationToken);

    public Task<Result<BookPageDto>> GetBookPageAsync(Guid bookId, int pageSize, int pageNumber, CancellationToken cancellationToken);

    public Task<Result> SaveProgressAsync(Guid bookId, int pageSize, int pageNumber, CancellationToken cancellationToken);
}