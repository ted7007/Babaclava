using Babaclava.Core.Books;
using Babaclava.Core.Books.Dto;
using Babaclava.Core.BookText;
using Babaclava.Core.Models;
using FluentResults;

namespace Babaclava.Application.Book;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IUserResultRepository _userResultRepository;
    private readonly IBookTextManager _bookTextManager;

    public BookService(IBookRepository bookRepository, IUserResultRepository userResultRepository, IBookTextManager bookTextManager)
    {
        _bookRepository = bookRepository;
        _userResultRepository = userResultRepository;
        _bookTextManager = bookTextManager;
    }
    
    public async Task<Result<IEnumerable<CatalogBookDto>>> GetCatalogAsync(int bookCount, int pageSize, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooksWIthResultAsync(bookCount, TestValues.UserId,  cancellationToken);
        var res =  books.Select(b => new CatalogBookDto
        {
            BookId = b.Book.Id,
            Title = b.Book.Title,
            Author = b.Book.Author,
            PageSize = pageSize,
            PageNumber = b.UserResult is null ? 0 : (int)(b.UserResult.CurrentPosition / pageSize),
            TotalPages = (int)Math.Round((double)b.Book.Size / pageSize, MidpointRounding.AwayFromZero)
        });
        
        return Result.Ok(res);
    }

    public async Task<Result<BookPageDto>> GetBookPageAsync(Guid bookId, int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookAsync(bookId, cancellationToken);
        if (book is null)
            return Result.Fail("Книга не найдена");
        var startPage = pageSize * pageNumber;

        if (startPage > book.Size)
            return Result.Fail("Книга закончилась");

        if (startPage + pageSize > book.Size)
            pageSize = book.Size - startPage;
        return await _bookTextManager.GetBookTextAsync(book.TextPath, startPage, pageSize, cancellationToken);
    }

    public async Task<Result> SaveProgressAsync(Guid bookId, int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookAsync(bookId, cancellationToken);
        if (book is null)
            return Result.Fail("Книга не найдена");
        
        var currentPos = pageSize * pageNumber;
        var userResult = await _userResultRepository.GetUserResultAsync(TestValues.UserId, bookId, cancellationToken);
        if (userResult is null)
        {    _userResultRepository.AddResultAsync(new UserResult()
                {
                    BookId = bookId,
                    UserId = TestValues.UserId,
                    CurrentPosition = currentPos

                }
                , cancellationToken);
            return Result.Ok();
        }

        userResult.CurrentPosition = currentPos;
        await _userResultRepository.UpdateResultAsync(userResult, cancellationToken);
        
        return Result.Ok();
    }
}