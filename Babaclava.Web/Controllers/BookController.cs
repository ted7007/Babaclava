using Babaclava.Core.Books.Commands;
using Babaclava.Core.Books.Dto;
using Babaclava.Core.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Babaclava.Web.Controllers;

/// <summary>
/// Контроллер для книг
/// </summary>
[ApiController]
[Route("api/v1/book")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение страницы книги
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet(("page"))]
    public async Task<ActionResult<BookPageDto>> GetBookPage([FromQuery] GetBookPageQuery query,
        CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(query, cancellationToken);
        return res.IsFailed ?
            new BadRequestObjectResult(res.Errors.First().Message) : new OkObjectResult(res.Value);
    }

    [HttpPost("save-result")]
    public async Task<ActionResult> SaveResult([FromBody] SaveUserResultCommand command,
        CancellationToken cancellationToken)
    {
        
        var res = await _mediator.Send(command, cancellationToken);
        return res.IsFailed ?
            new BadRequestObjectResult(res.Errors.First().Message) : new OkResult();
    }
}