using Babaclava.Core.Books;
using Babaclava.Core.Books.Dto;
using Babaclava.Core.Books.Queries;
using FluentResults;
using MediatR;

namespace Babaclava.Application.Book;

public class BookQueryHandler : IRequestHandler<GetBookPageQuery, Result<BookPageDto>>
{
    private readonly IBookService _bookService;

    public BookQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public async Task<Result<BookPageDto>> Handle(GetBookPageQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetBookPageAsync(request.BookId, request.PageSize, request.PageNumber, cancellationToken);
    }
}