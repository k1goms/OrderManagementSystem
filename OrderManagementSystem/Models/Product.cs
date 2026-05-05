using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Models;

public class Product
{

    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public ProductCategory category { get; set; }

    public Product(long id, string name, decimal price, ProductCategory category)
    {
        Id = id;
        Name = name;
        Price = price;
        this.category = category;
    }

    public override string? ToString()
    {
        return $"[{Id} | {Name} | ${Price:F2}] | {category}";
    }
}
