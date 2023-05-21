using MediatR;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Web.Products.Model;

namespace ProductsOrganizer.Web.Products.Queries;

public record GetProductsRequest : IRequest<IEnumerable<ProductDto>>
{
    public int Skip { get; init; }
    public int Take { get; init; }
}

public class GetProductsHandler : IRequestHandler<GetProductsRequest, IEnumerable<ProductDto>>
{
    private readonly IProductRepository productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public async Task<IEnumerable<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsAsync(request.Take, request.Skip);
        return products.Select(x => new ProductDto(x));
    }
}