namespace ProductsOrganizer.Domain;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(int take, int skip);
    Task<Product> GetProductAsync(Guid productId);
    Task DeleteProductAsync(Guid productId);
}