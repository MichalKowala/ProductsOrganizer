﻿using ProductsOrganizer.Domain;

namespace ProductsOrganizer.Persistence;

public class ProductRepository : IProductRepository
{
    //normally this would be our DbContext
    private List<Product> fakeContext = new()
    {
        new Product
        {
            Code = "00001",
            Name = "Plasma TV full HD",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus et aliquet leo. Pellentesque finibus arcu nec nibh tincidunt, id tincidunt magna mattis.",
            Price = 50
        },
        new Product()
        {
            Code = "30221",
            Name = "Blootooth speaker",
            Description = "Mauris gravida ante eget lacus efficitur, non fermentum ipsum suscipit. Aliquam feugiat tempus orci. Maecenas ut commodo tellus.",
            Price = 75.23M
        },
        new Product()
        {
            Code = "420BZ",
            Name = "Desk lamp",
            Description = "Vivamus porttitor orci dui, eu tempus tortor pretium nec. Mauris id aliquet lectus. Aenean facilisis ipsum quis dolor suscipit porttitor.",
            Price = 7528
        },
        new Product()
        {
            Code = "ABCDE",
            Name = "Air purifier",
            Description = "Vivamus porttitor orci dui, eu tempus tortor pretium nec. Mauris id aliquet lectus. Aenean facilisis ipsum quis dolor suscipit porttitor.",
            Price = 222.22M
        },
        new Product()
        {
            Code = "BBBDD",
            Name = "Coffee grinder",
            Description = "Sed convallis dui ut euismod tristique. Cras pharetra consectetur lacus, non vestibulum tellus sagittis sed. Donec sodales imperdiet turpis nec interdum.",
            Price = 156.23M
        },
        new Product()
        {
            Code = "12352",
            Name = "Electric toothbrush",
            Description = "Vivamus condimentum, augue vitae maximus viverra, massa est varius est, ut suscipit dolor nulla at erat. Sed nec dignissim diam. Vivamus quis risus in augue ullamcorper auctor",
            Price = 6312
        },
        new Product()
        {
            Code = "54321",
            Name = "Logitech keyboard",
            Description = "Vivamus porttitor orci dui, eu tempus tortor pretium nec. Mauris id aliquet lectus. Aenean facilisis ipsum quis dolor suscipit porttitor.",
            Price = 222.22M
        },
        new Product()
        {
            Code = "REWQS",
            Name = "Samsung s6",
            Description = "Cras nec lacus at lectus finibus suscipit vel quis dolor. Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 55553.6M
        },
        new Product()
        {
            Code = "REWQS",
            Name = "iPhone 12",
            Description = "Cras nec lacus at lectus finibus suscipit vel quis dolor. Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 553.6M
        },
        new Product()
        {
            Code = "REWQS",
            Name = "google pixel6",
            Description = "Cras nec lacus at lectus finibus suscipit vel quis dolor. Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 553.6M
        },
        new Product()
        {
            Code = "AGQWS",
            Name = "some other phone",
            Description = "Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 123.6M
        },
        new Product()
        {
            Code = "BBBBB",
            Name = "and another phone",
            Description = "Cras nec lacus at lectus finibus suscipit vel quis dolor. Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 53.6M
        },
        new Product()
        {
            Code = "CCCCC",
            Name = "and one more phone",
            Description = "Cras nec lacus at lectus finibus suscipit vel quis dolor. Integer ac orci aliquet, dapibus dolor aliquam, euismod risus. Donec hendrerit, ligula vel suscipit dignissim, nunc augue gravida leo, a elementum nulla arcu nec urna. ",
            Price = 553.6M
        },
        new Product()
        {
            Code = "DDDDD",
            Name = "Some product 1",
            Description = "Some description 1",
            Price = 10
        },
        new Product()
        {
            Code = "P1002",
            Name = "Some product 2",
            Description = "Sed convallis dui ut euismod tristique. Cras pharetra consectetur lacus, non vestibulum tellus sagittis sed. Donec sodales imperdiet turpis nec interdum.",
            Price = 20
        }
    };
    
    public async Task<IEnumerable<Product>> GetProductsAsync(int take, int skip)
    {
        await Task.Delay(50); //delay to simulate the asynchrony of a real repository
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

    public async Task UpdateProductAsync(Product product)
    {
        await Task.Delay(50);
        //Computer: updating  *beep boop*
    }
    
    public async Task AddProductAsync(Product product)
    {
        await Task.Delay(50);
        fakeContext.Add(product);
    }

    public int GetProductsCount()
    {
        return fakeContext.Count();
    }
}