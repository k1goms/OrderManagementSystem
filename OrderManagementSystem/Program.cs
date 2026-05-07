using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;

public class Program
{
    static void Main(string[] args)
    {

        var repository = new ProductRepository();

        foreach (var item in repository.GetAll())
        {
            Console.WriteLine(item);
        }

        var service = new ProductService(repository);

        var product = new CreateProductDto("Teste", 10.0m, ProductCategory.Snack);

        service.Add(product);

        var product2 = new CreateProductDto("Teste", 10.0m, ProductCategory.Snack);

        service.Add(product2);

        foreach (var item in repository.GetAll())
        {
            Console.WriteLine(item);
        }

    }
}
