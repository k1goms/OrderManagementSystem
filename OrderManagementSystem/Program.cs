using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using OrderManagementSystem.UI;

public class Program
{
    static void Main(string[] args)
    {

        var productRepository = new ProductRepository();
        var orderRepository = new OrderRepository();

        var productService = new ProductService(productRepository);
        var orderService = new OrderService(orderRepository, productRepository);

        var menu = new Menu(productService, orderService);
        menu.Run();

    }
}
