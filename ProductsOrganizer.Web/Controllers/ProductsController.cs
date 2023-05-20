using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Web.Products.Model;
using ProductsOrganizer.Web.Products.Queries;

namespace ProductsOrganizer.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator mediator;
    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRange([FromQuery] int skip, [FromQuery] int take)
    {
        var result = await mediator.Send(new GetProductsRequest {Skip = skip, Take = take});
        return Ok(result);
    }
}