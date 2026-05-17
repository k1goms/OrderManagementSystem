using OrderManagementSystem.Enums;

namespace OrderManagementSystem.DTOs;

public record CreateProductDto
    (
      string Name, 
      decimal  Price,
      ProductCategory Category
    ) {}
