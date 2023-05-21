namespace ProductsOrganizer.Domain;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetRange(int take, int skip);
    Task DeleteProduct(Guid productId);
}