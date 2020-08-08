using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Repositories.Queries
{
    public static class BookQueries
    {
        public const string GetAllBook = @"
                    SELECT 
                        id AS Id, 
                        title AS Title, 
                        author_id AS AuthorId, 
                        price AS Price 
                    FROM shop.book";

        public const string CreateBook = @"
                INSERT INTO shop.book (title, author_id, price)
                VALUES (@Title, @AuthorId, @Price) RETURNING id";

        public const string GetBookById = @"SELECT 
                        id AS Id, 
                        title AS Title,
                        author_id AS AuthorId,
                        price AS Price
                        FROM shop.book
                        WHERE id=@id";

        public const string GetBookIdByTitle = @"
                SELECT id AS Id 
                FROM shop.book 
                WHERE title = @title";

        public const string GetBookByAuthorId = @"
                SELECT 
                       id AS Id,
                       title AS Title,
                       author_id AS AuthorId,
                       price AS Price
                       FROM shop.book
                       WHERE author_id = @author_id";

        public const string DeleteBookFromOrders = @"
                           DELETE FROM shop.order_book 
                           WHERE book_id = @book_id";

        public const string DeleteBookByTitle = @"
                DELETE FROM shop.book
                WHERE title = @Title
                RETURNING
                         id AS Id, 
                         title AS Title,
                         author_id AS AuthorId,
                         price AS Price";

        public const string GetBookByTitle = @"
                SELECT 
                        id AS Id, 
                        title AS Title,
                        author_id AS AuthorId,
                        price AS Price
                        FROM shop.book
                        WHERE title = @title";

        public const string DeleteBookByAuthorId = @"
                DELETE FROM shop.book
                WHERE author_id = @author_id";

        public const string DeleteBooksFromOrdersByIds = @"
                DELETE FROM shop.order_book
                WHERE  book_id = ANY(@book_id)";
    }
}
