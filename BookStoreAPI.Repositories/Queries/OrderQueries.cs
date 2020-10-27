using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Repositories.Queries
{
    public static class OrderQueries
    {
       public const string CreateOrder = @"
                                           INSERT INTO shop.shop_order (customer_id)
                                           VALUES (@CustomerId) RETURNING id";
    }
}
