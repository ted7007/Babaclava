using Babaclava.Core.Books;
using Babaclava.Core.Books.Dto;
using Babaclava.Core.Books.Queries;
using FluentResults;
using MediatR;

namespace Babaclava.Application.Book;

public class CatalogQueryHandler : IRequestHandler<GetCatalogQuery,Result<IEnumerable<CatalogBookDto>>>
{
    private readonly IBookService _bookService;

    public CatalogQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    public async Task<Result<IEnumerable<CatalogBookDto>>> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
    {
        return await _bookService.GetCatalogAsync(request.Count, request.PageSize, cancellationToken);
    }
}