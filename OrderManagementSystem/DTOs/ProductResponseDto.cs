namespace OrderManagementSystem.DTOs;

public record ProductResponseDto
    (
        long Id,
        string Name,
        decimal Price,
        string Category
    );

