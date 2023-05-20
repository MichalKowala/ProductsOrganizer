using ProductsOrganizer.Domain;

namespace ProductsOrganizer.Web.Products.Model;

public record ProductDto
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    
    public ProductDto(Product model)
    {
        Id = model.Id;
        Code = model.Code;
        Name = model.Name;
        Description = model.Description;
        DateCreated = model.DateCreated;
    }
}