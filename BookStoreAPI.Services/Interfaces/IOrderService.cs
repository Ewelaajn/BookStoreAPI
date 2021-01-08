using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IOrderService
    {
        OrderDto OrderBook(string title, string mail);
    }
}
