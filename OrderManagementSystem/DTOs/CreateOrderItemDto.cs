using OrderManagementSystem.Models;

namespace OrderManagementSystem.DTOs;

public record CreateOrderItemDto
    (
        long ProductId,
        int Qty
    );
