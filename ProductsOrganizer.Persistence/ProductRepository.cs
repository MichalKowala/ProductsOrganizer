using ProductsOrganizer.Domain;

namespace ProductsOrganizer.Persistence;

public class ProductRepository : IProductRepository
{
    //normally this would be our DbContext
    private List<Product> fakeContext = new()
    {
        new Product
        {
            Code = "0001",
            Name = "Produkt 1",
            Description = "asdasdasd"
        },
        new Product()
        {
            Code = "0002",
            Name = "Produkt 2",
            Description = "asdasopdiaosdoiasd"
        }
    };
    
    public async Task<IEnumerable<Product>> GetProductsAsync(int take, int skip)
    {
        await Task.Delay(50);
        return fakeContext.Skip(skip).Take(take);
    }

    public async Task<Product> GetProductAsync(Guid productId)
    {
        await Task.Delay(50);
        var product = fakeContext.FirstOrDefault(x => x.Id == productId);
        if (product is null)
            throw new Exception("Product not found");
        return product;
    }

    public async Task DeleteProductAsync(Guid productId)
    {
        await Task.Delay(50);
        var productToRemove = fakeContext.FirstOrDefault(x => x.Id == productId);
        if (productToRemove is null)
            throw new Exception("Product not found");
        fakeContext.Remove(productToRemove);
    }
}