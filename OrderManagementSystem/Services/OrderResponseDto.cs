using OrderManagementSystem.Enums;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services;

public record OrderResponseDto
    (
        long Id,
        string CustomerName,
        string Status,
        List<string> Items,
        DateTime CreatedAt,
        decimal Total
    );