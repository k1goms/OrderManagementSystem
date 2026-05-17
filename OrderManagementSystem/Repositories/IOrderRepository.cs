using OrderManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Repositories;

public interface IOrderRepository
{
    Order GetById(long id);
    void Add(Order item);
    void Remove(long id);
    List<Order> GetAll();
}
