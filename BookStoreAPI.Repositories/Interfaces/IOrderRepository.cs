using System.Collections;
using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Order CreateOrder(string title, string mail);
        IEnumerable<Order> GetOrdersByIds(List<int> ids);
    }
}