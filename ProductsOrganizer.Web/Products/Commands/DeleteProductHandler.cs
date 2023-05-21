using MediatR;
using ProductsOrganizer.Domain;
using ProductsOrganizer.Persistence;

namespace ProductsOrganizer.Web.Products.Commands;

public record DeleteProductRequest : IRequest<Unit>
{
    public Guid Id { get; init; }
}

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, Unit>
{
    private readonly IProductRepository productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    
    public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await productRepository.DeleteProductAsync(request.Id);
        return Unit.Value;
    }
}