using Microsoft.Extensions.DependencyInjection;
using ProductsOrganizer.Domain;

namespace ProductsOrganizer.Persistence;

public static class PersistenceServicesInstaller
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
        return services;
    }
}