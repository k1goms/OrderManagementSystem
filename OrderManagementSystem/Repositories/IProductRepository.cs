using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Repositories;

public interface IProductRepository
{
    Product GetById(long id);
    void Add(Product product);
    void Remove(long id);
    List<Product> GetAll();
}
