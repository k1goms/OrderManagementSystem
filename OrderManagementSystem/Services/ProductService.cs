using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.SampleData;

namespace OrderManagementSystem.Services;

public class ProductService
{
    private IProductRepository _repository;
    private long _nextId;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
        _nextId = _repository.GetAll().Any()
        ? _repository.GetAll().Max(p => p.Id) + 1
        : 1;
    }

    public void Add(CreateProductDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required");
        if (dto.Price < 0)
            throw new ArgumentException("Price must be greater than zero.");

        _repository.Add(new Product(_nextId++, dto));
    }

}
