using Babaclava.Core.Books;
using Babaclava.Core.Books.Commands;
using FluentResults;
using MediatR;

namespace Babaclava.Application.Book;

public class UserResultCommandHandler : IRequestHandler<SaveUserResultCommand, Result>
{
    private readonly IBookService _bookService;

    public UserResultCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public async Task<Result> Handle(SaveUserResultCommand request, CancellationToken cancellationToken)
    {
        return await _bookService.SaveProgressAsync(request.BookId, request.PageSize, request.PageNumber, cancellationToken);
    }
}