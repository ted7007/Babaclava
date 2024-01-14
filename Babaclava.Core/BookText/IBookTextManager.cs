using Babaclava.Core.Books.Dto;
using FluentResults;

namespace Babaclava.Core.BookText;

public interface IBookTextManager
{
    public Task<Result<string>> GetBookTextAsync(string filePath, int startPos, int count, CancellationToken cancellationToken);
}