using MediatR;
using ProductsOrganizer.Domain;

namespace ProductsOrganizer.Web.Products.Queries;

public record GetProductsCountRequest : IRequest<int>
{
}

public class GetProductsCountHandler : IRequestHandler<GetProductsCountRequest, int>
{
    private readonly IProductRepository productRepository;
    public GetProductsCountHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    public Task<int> Handle(GetProductsCountRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(productRepository.GetProductsCount());
    }
}