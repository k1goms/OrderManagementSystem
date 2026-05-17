using OrderManagementSystem.DTOs;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;

namespace OrderManagementSystem.Services;

public class ProductService
{
    private readonly IProductRepository _repository;
    private long _nextId;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
        _nextId = _repository.GetAll().Any() ?
            _repository.GetAll().Max(p => p.Id) + 1
            : 1;
    }

    public void CreateProduct(CreateProductDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required");
        if (dto.Price < 0)
            throw new ArgumentException("Price must be greater than zero.");

        _repository.Add(new Product(_nextId++, dto));
    }

    public void Remove(long id)
    {
        _repository.Remove(id);
    }

    private ProductResponseDto ToDto(Product product)
    {
        return new ProductResponseDto(
            product.Id,
            product.Name,
            product.Price,
            product.Category.ToString()
        );
    }

    public List<ProductResponseDto> GetAll()
    {
        return _repository.GetAll()
            .Select(p => ToDto(p))
            .ToList();
    }

    public ProductResponseDto GetById(long id)
    {
        var product = _repository.GetById(id);
        return ToDto(product);

    }



}
