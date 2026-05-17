using OrderManagementSystem.DTOs;
using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;

namespace OrderManagementSystem.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private long _nextId;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _nextId = _orderRepository.GetAll().Any()
            ? _orderRepository.GetAll().Max(o => o.Id) + 1
            : 1;
    }

    public void CreateOrder(CreateOrderDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.CustomerName))
            throw new ArgumentException("Costumer name is required.");

        _orderRepository.Add(new Order(_nextId++, dto));
    }

    public void Remove(long id)
    {
        _orderRepository.Remove(id);
    }

    public void AddItem(long orderId, CreateOrderItemDto dto)
    {
        var order = _orderRepository.GetById(orderId);
        var product = _productRepository.GetById(dto.ProductId);
        var item = new OrderItem(product, dto.Qty);
        order.AddItem(item);
    }

    private OrderResponseDto ToDto(Order order)
    {
        return new OrderResponseDto(
            order.Id,
            order.CustomerName,
            order.Status.ToString(),
            order.Items.Select(i => i.ToString()).ToList(),
            order.CreatedAt,
            order.Total
        );
    }

    public List<OrderResponseDto> GetAll()
    {
        return _orderRepository.GetAll()
            .Select(o => ToDto(o))
            .ToList();
    }

    public OrderResponseDto GetById(long id)
    {
        var order = _orderRepository.GetById(id);
        return ToDto(order);
    }

    public void UpdateStatus(long orderId, OrderStatus newStatus)
    {
        var order = _orderRepository.GetById(orderId);

        if (order.Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot change status of a delivered order.");
        if (order.Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Cannot change status of a cancelled order.");

        order.Status = newStatus;
    }

    public void Cancel(long orderId)
    {
        var order = _orderRepository.GetById(orderId);

        if (order.Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot cancel a delivered order.");

        order.Status = OrderStatus.Cancelled;
    }

}
