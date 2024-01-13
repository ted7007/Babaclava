using System.ComponentModel.DataAnnotations;
using Babaclava.Core.Books.Dto;
using FluentResults;
using MediatR;

namespace Babaclava.Core.Books.Queries;

public class GetBookPageQuery : IRequest<Result<BookPageDto>>
{
    public Guid BookId { get; set; }

    [Range(1, 9999)]
    public int PageSize { get; set; }

    [Range(0, 9999)]
    public int PageNumber { get; set; }
}