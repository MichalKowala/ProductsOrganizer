using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductsOrganizer.Web.Products.Commands;
using ProductsOrganizer.Web.Products.Queries;

namespace ProductsOrganizer.Web.Controllers;

[ApiController]
[Route("api/products")]
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await mediator.Send(new DeleteProductRequest {Id = id});
        return Ok(NoContent());
    }
}