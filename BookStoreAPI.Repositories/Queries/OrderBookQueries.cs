namespace BookStoreAPI.Repositories.Queries
{
    public static class OrderBookQueries
    {
        public const string CreateOrderBook = @"
                                               INSERT INTO shop.order_book (order_id, book_id)
                                               VALUES (@OrderId, @BookId) RETURNING order_id";

        public const string GetOrderedBooks = @"SELECT
                                                    order_id AS OrderId,
                                                    book_id AS BookId
                                                FROM shop.order_book";


    }
}