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
    
    public async Task<IEnumerable<Product>> GetRange(int take, int skip)
    {
        await Task.Delay(50);
        return fakeContext.Skip(skip).Take(take);
    }
}