using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories;

public class OrderRepository : IOrderRepository
{

    private readonly List<Order> _orders = new List<Order>();

    public Order GetById(long id)
    {
        return _orders.FirstOrDefault(o => o.Id == id)
            ?? throw new KeyNotFoundException($"Order with id {id} not found");
    }

    public void  Add(Order item)
    {
        _orders.Add(item);
    }

    public void Remove(long id)
    {
        var item = GetById(id);
        _orders.Remove(item);
    }

    public List<Order> GetAll()
    {
        return new List<Order>(_orders);
    }

}
