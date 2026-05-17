using OrderManagementSystem.DTOs;
using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Models;

public class Product
{

    public long Id { get; private set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductCategory Category { get; set; }

    public Product(long id, string name, decimal price, ProductCategory category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public Product(long id, CreateProductDto dto)
        : this(id, dto.Name, dto.Price, dto.Category)
    {
    }

    public override string? ToString()
    {
        return $"[{Id} | {Name} | ${Price:F2}] | {Category}";
    }
}
