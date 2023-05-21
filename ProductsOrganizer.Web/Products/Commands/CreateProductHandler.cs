using MediatR;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Web.Products.Model;

namespace ProductsOrganizer.Web.Products.Commands;

public record CreateProductRequest : IRequest<ProductDto>
{
    public string Code { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}

public class CreateProductHandler : IRequestHandler<CreateProductRequest, ProductDto>
{
    private readonly IProductRepository productRepository;
    public CreateProductHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public async Task<ProductDto> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var newProduct = new Product()
        {
            Code = request.Code,
            Description = request.Description,
            Name = request.Name,
            Price = request.Price
        };
        await productRepository.AddProductAsync(newProduct);
        return new ProductDto(newProduct);
    }
}