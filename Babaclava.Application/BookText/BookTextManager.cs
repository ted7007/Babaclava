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
    public async Task<Result<string>> GetBookTextAsync(string filePath, int startPos, int count, CancellationToken cancellationToken)
    {
        try
        {
            var directoryPath = Path.Combine(_environment.ContentRootPath, "Books");
            using (var reader = new FileStream(Path.Combine(directoryPath, filePath), FileMode.Open, FileAccess.Read))
            {
                var res = new char[count];
                string text = "";
                reader.Seek(startPos, SeekOrigin.Begin);
                using (var sr = new StreamReader(reader, Encoding.UTF8, true))
                {
                    await sr.ReadBlockAsync(res, 0, count);
                    return Result.Ok(new string(res));
                }
            }
        }
        catch (Exception e)
        {
            return Result.Fail("Ошибка при загрузке текста книги");
        }
    }
}