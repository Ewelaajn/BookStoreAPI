namespace BookStoreAPI.Repositories.Queries
{
    public static class OrderQueries
    {
        public const string CreateOrder = @"
                                           INSERT INTO shop.shop_order (customer_id)
                                           VALUES (@CustomerId)
                                           RETURNING 
                                                   id AS Id,
                                                   is_active AS IsActive,
                                                   order_time AS OrderTime,
                                                   customer_id AS CustomerId";

        public const string GetOrdersByIds = @"SELECT
                                                id AS Id,
                                                is_active AS IsActive,
                                                order_time AS OrderTime,
                                                customer_id AS CustomerId
                                            FROM shop.shop_order
                                            WHERE id = ANY(@ids)";
    }
}