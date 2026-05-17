using OrderManagementSystem.DTOs;
using OrderManagementSystem.Enums;

namespace OrderManagementSystem.Models;

public class Order
{
    public long Id { get; set; }
    public string CustomerName { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public decimal Total { get; private set; }

    public Order(long id, CreateOrderDto dto)
    {
        Id = id;
        CustomerName = dto.CustomerName;
        Status = OrderStatus.Pending;
        Items = new List<OrderItem>();
        CreatedAt = DateTime.Now;
        Total = 0;
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        Total = Items.Sum(i => i.Subtotal);
    }

    public override string ToString()
    {
        var items = string.Join("\n  ", Items.Select(i => i.ToString()));
        return $"[Order #{Id} | {CustomerName} | {Status} | {CreatedAt:dd/MM/yyyy HH:mm}]\n  {items}\n  Total: ${Total:F2}";
    }


}
