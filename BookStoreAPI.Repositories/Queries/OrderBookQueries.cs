using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Repositories.Queries
{
    public static class OrderBookQueries
    {
       public const string CreateOrderBook =  @"
                                               INSERT INTO shop.order_book (order_id, book_id)
                                               VALUES (@OrderId, @BookId) RETURNING order_id";
    }
}
