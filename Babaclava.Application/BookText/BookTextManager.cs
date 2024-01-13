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
            using (var reader = new StreamReader(File.OpenRead(Path.Combine(directoryPath, filePath))))
            {
                var res = new char[count];
                var readCount = await reader.ReadBlockAsync(res, startPos, count);
                if (readCount == 0)
                    return Result.Fail("Текст книги закончился");
                var pageRes = new BookPageDto
                {
                    Text = new string(res),
                    HasNextPage = !reader.EndOfStream,
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