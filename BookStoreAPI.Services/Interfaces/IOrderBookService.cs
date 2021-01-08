using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IOrderBookService
    {
        IEnumerable<OrderDto> GetOrderedBooks();
    }
}
