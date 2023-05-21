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
    public async Task<IActionResult> GetProducts([FromQuery] int skip, [FromQuery] int take)
    {
        var result = await mediator.Send(new GetProductsRequest {Skip = skip, Take = take});
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        var result = await mediator.Send(new GetProductRequest {Id = id});
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        await mediator.Send(new DeleteProductRequest {Id = id});
        return Ok(NoContent());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductRequest request)
    {
        var result = await mediator.Send(request with {Id = id});
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
}