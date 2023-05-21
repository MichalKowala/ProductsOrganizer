using MediatR;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Web.Products.Model;

namespace ProductsOrganizer.Web.Products.Queries;

public record GetProductRequest : IRequest<ProductDto>
{
    public Guid Id { get; set; }
}

public class GetProductHandler : IRequestHandler<GetProductRequest, ProductDto>
{
    private readonly IProductRepository productRepository;
    public GetProductHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductAsync(request.Id);
        return new ProductDto(product);
    }
}