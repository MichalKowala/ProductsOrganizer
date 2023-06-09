﻿namespace ProductsOrganizer.Domain;

public class Product : Entity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}