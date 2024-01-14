using System.Text;
using Babaclava.Core.Books.Dto;
using Babaclava.Core.BookText;
using FluentResults;
using Microsoft.Extensions.Hosting;

namespace Babaclava.Application.BookText;

public class BookTextManager : IBookTextManager
{
    private readonly IHostEnvironment _environment;

    public BookTextManager(IHostEnvironment environment)
    {
        _environment = environment;
    }
    public async Task<Result<BookPageDto>> GetBookTextAsync(string filePath, int startPos, int count, CancellationToken cancellationToken)
    {
        try
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "Books");
            using (var reader = (File.OpenRead(Path.Combine(directoryPath, filePath))))
            {
                var res = new byte[count];
                reader.Seek(startPos, SeekOrigin.Begin);
                await reader.ReadAsync(res, 0, count, cancellationToken);
                var pageRes = new BookPageDto
                {
                    Text = Encoding.UTF8.GetString(res),
                    HasNextPage = reader.Length > startPos + count,
                    HasPreviousPage = startPos > 0,
                    PageSize = count
                };
                return Result.Ok(pageRes);
            }
        }
        catch (Exception e)
        {
            return Result.Fail("Ошибка при загрузке текста книги");
        }
    }
}