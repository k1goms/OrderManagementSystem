using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.SampleData;

public class SampleProducts
{
    public static List<Product> genericList = 
        [
            new Product(1, "X-Burguer", 20.0m, ProductCategory.Snack),
            new Product(2, "X-Bacon", 20.0m, ProductCategory.Snack),
            new Product(3, "Coke", 5.0m, ProductCategory.Drink),
            new Product(4, "Milkshake", 10m, ProductCategory.Dessert),
            new Product(5, "Cookie", 5.0m, ProductCategory.Dessert),
            new Product(6, "Orange Juice", 3.0m, ProductCategory.Drink),
            new Product(7, "X-Burguer Combo", 31.0m, ProductCategory.Snack),
        ];
}
