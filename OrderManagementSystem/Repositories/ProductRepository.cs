using OrderManagementSystem.Models;
using OrderManagementSystem.SampleData;

namespace OrderManagementSystem.Repositories;

public class ProductRepository : IProductRepository
{

    private List<Product> _products = new List<Product>(SampleProducts.genericList);

    public Product GetById(long id)
    {
        return _products.FirstOrDefault(p => p.Id == id)
            ?? throw new KeyNotFoundException($"Product with id {id} not found");
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Remove(long id)
    {
        var product = GetById(id);
        _products.Remove(product);
    }

    public List<Product> GetAll()
    {
        return new List<Product>(_products);
    }

}
