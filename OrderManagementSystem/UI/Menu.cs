using OrderManagementSystem.DTOs;
using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.UI;

public class Menu
{
    private readonly ProductService _productService;
    private readonly OrderService _orderService;

    public Menu(ProductService productService, OrderService orderService)
    {
        _productService = productService;
        _orderService = orderService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== Order Management System ===");
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Orders");
            Console.WriteLine("0. Exit");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1": ProductsMenu(); break;
                case "2": OrdersMenu(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    //---------------------------PRODUCTS-MENU-----------------------------------


    private void ProductsMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Products ===");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Add product");
            Console.WriteLine("3. Remove product");
            Console.WriteLine("0. Back");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1": ListProducts(); break;
                case "2": AddProduct(); break;
                case "3": RemoveProduct(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void PrintProduct(ProductResponseDto p)
    {
        Console.WriteLine($"{p.Id} | {p.Name} | ${p.Price:F2} | {p.Category}");
    }

    private void ListProducts()
    {
        Console.WriteLine("=====PRODUCTS=====\n");
        foreach (var product in _productService.GetAll())
        {
            PrintProduct(product);
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Name: ");
        var name = Console.ReadLine();

        Console.WriteLine("Price: ");
        var price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Category: ");
        Console.WriteLine("1. Drink");
        Console.WriteLine("2. Snack");
        Console.WriteLine("3. Dessert");
        Console.WriteLine("4. Combo");
        Console.Write("Option: ");

        ProductCategory category;

        switch (Console.ReadLine())
        {
            case "1": category = ProductCategory.Drink; break;
            case "2": category = ProductCategory.Snack; break;
            case "3": category = ProductCategory.Dessert; break;
            case "4": category = ProductCategory.Combo; break;
            default: Console.WriteLine("Invalid option."); return;
        }

        try
        {
            _productService.CreateProduct(new CreateProductDto(name, price, category));
            Console.WriteLine("Product added successfully!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    private void RemoveProduct()
    {
        ListProducts();
        Console.WriteLine("\nId: ");
        var id = long.Parse(Console.ReadLine());

        try
        {
            _productService.Remove(id);
            Console.WriteLine("Product removed successfully!");
        }
        catch (KeyNotFoundException ex) { Console.WriteLine($"Error: {ex.Message}"); }
        catch (FormatException) { Console.WriteLine("Invalid id."); }

    }

    //---------------------------ORDERS-MENU-----------------------------------

    private void OrdersMenu()
    {
        while (true)
        {
            Console.WriteLine("\n=== Orders ===");
            Console.WriteLine("1. List all");
            Console.WriteLine("2. Create order");
            Console.WriteLine("3. Add item to order");
            Console.WriteLine("4. Update status");
            Console.WriteLine("5. Cancel order");
            Console.WriteLine("0. Back");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1": ListOrders(); break;
                case "2": CreateOrder(); break;
                case "3": AddItem(); break;
                case "4": UpdateStatus(); break;
                case "5": CancelOrder(); break;
                case "0": return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void PrintOrder(OrderResponseDto o)
    {
        Console.WriteLine($"[{o.Id} | {o.CustomerName} | {o.Status} | {o.CreatedAt:dd/MM/yyyy HH:mm}]");
        foreach (var item in o.Items)
        {
            Console.WriteLine($"  {item}");
        }
        Console.WriteLine($"  Total: ${o.Total:F2}");
    }
    private void ListOrders()
    {
        Console.WriteLine("=====ORDERS=====\n");
        foreach (var order in _orderService.GetAll())
        {
            PrintOrder(order);
        }
    }

    private void CreateOrder()
    {
        Console.Write("Your name: ");
        var name = Console.ReadLine();

        try
        {
            _orderService.CreateOrder(new CreateOrderDto(name));
            Console.WriteLine("Order created successfully!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private void AddItem()
    {
        ListOrders();
        Console.WriteLine("Order ID: ");
        var orderId = long.Parse(Console.ReadLine());

        ListProducts();
        Console.Write("Product ID: ");
        var productId = long.Parse(Console.ReadLine());

        Console.Write("Quantity: ");
        var quantity = int.Parse(Console.ReadLine());

        try
        {
            _orderService.AddItem(orderId, new CreateOrderItemDto(productId, quantity));
            Console.WriteLine("Item added successfully!");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    private void UpdateStatus()
    {
        ListOrders();
        Console.WriteLine("Order ID: ");
        var orderId = long.Parse(Console.ReadLine());

        Console.WriteLine("Status: ");
        Console.WriteLine("1. Pending");
        Console.WriteLine("2. Preparing");
        Console.WriteLine("3. Ready");
        Console.WriteLine("4. Delivered");
        Console.Write("Option: ");

        OrderStatus orderStatus;

        switch (Console.ReadLine())
        {
            case "1": orderStatus = OrderStatus.Pending; break;
            case "2": orderStatus = OrderStatus.Preparing; break;
            case "3": orderStatus = OrderStatus.Ready; break;
            case "4": orderStatus = OrderStatus.Delivered; break;
            default: Console.WriteLine("Invalid option."); return;
        }

        try
        {
            _orderService.UpdateStatus(orderId, orderStatus);
            Console.WriteLine("Status updated successfully!");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }

    private void CancelOrder()
    {
        ListOrders();
        Console.Write("Order ID: ");
        var orderId = long.Parse(Console.ReadLine());

        try
        {
            _orderService.Cancel(orderId);
            Console.WriteLine("Order cancelled successfully!");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
