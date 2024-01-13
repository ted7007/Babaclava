using System.ComponentModel.DataAnnotations;
using Babaclava.Core.Books.Dto;
using FluentResults;
using MediatR;

namespace Babaclava.Core.Books.Queries;

public class GetCatalogQuery : IRequest<Result<IEnumerable<CatalogBookDto>>>
{
    [Range(1, 9999)]
    public int Count { get; set; }

    [Range(1, 9999)]
    public int PageSize { get; set; }
}