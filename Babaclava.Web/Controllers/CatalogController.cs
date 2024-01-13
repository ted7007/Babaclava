using Babaclava.Core.Books.Dto;
using Babaclava.Core.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Babaclava.Web.Controllers;

[ApiController]
[Route("api/v1/catalog")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerator<CatalogBookDto>>> GetCatalog([FromQuery] GetCatalogQuery query,
        CancellationToken cancellationToken)
    {
        var res = await _mediator.Send(query);
        return res.IsFailed ?
            new BadRequestObjectResult(res.Errors.First().Message) : new OkObjectResult(res.Value);
    }
}