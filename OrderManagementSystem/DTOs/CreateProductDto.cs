using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Models;

public record CreateProductDto
    (
      string Name, 
      decimal  Price,
      ProductCategory Category
    ) {}
