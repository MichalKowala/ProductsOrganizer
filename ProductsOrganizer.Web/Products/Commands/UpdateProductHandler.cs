using MediatR;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Web.Products.Model;

namespace ProductsOrganizer.Web.Products.Commands;

public record UpdateProductRequest : IRequest<ProductDto>
{
    public Guid Id { get; init; }
    public string Code { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}

public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, ProductDto>
{
    private readonly IProductRepository productRepository;
    public UpdateProductHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var toUpdate = await productRepository.GetProductAsync(request.Id);
        UpdateModel(toUpdate, request);
        await productRepository.UpdateProductAsync(toUpdate);
        return new ProductDto(toUpdate);
    }

    private void UpdateModel(Product dbProduct, UpdateProductRequest requestProduct)
    {
        dbProduct.Code = requestProduct.Code;
        dbProduct.Description = requestProduct.Description;
        dbProduct.Name = requestProduct.Name;
        dbProduct.Price = requestProduct.Price;
    }
}