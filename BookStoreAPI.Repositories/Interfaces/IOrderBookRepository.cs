using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface IOrderBookRepository
    {
        IEnumerable<OrderBook> GetOrderedBooks();
    }
}