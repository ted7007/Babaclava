using System.ComponentModel.DataAnnotations;
using FluentResults;
using MediatR;

namespace Babaclava.Core.Books.Commands;

public class SaveUserResultCommand : IRequest<Result>
{
    [Required]
    public Guid BookId { get; set; }

    [Range(1, 9999)]
    public int PageSize { get; set; }

    [Range(1, 9999)]
    public int PageNumber { get; set; }
}