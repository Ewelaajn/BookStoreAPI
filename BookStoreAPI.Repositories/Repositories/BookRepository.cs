using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using Dapper;
using Npgsql;

namespace BookStoreAPI.Repositories.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDb _db;

        public BookRepository(IDb db)
        {
            _db = db;
        }
        public IEnumerable<Book> GetAllBooks()
        {
            var resultConnectionBook =_db.Connection.Query<Book>(
                @"SELECT 
                        id AS Id, 
                        title AS Title, 
                        author_id AS AuthorId, 
                        price AS Price 
                    FROM shop.book");
            return resultConnectionBook;
        }

        public Book CreateBook(Book book)
        {
            var insertedId = _db.Connection.QueryFirst<int>(@"
                INSERT INTO shop.book (title, author_id, price)
                VALUES (@Title, @AuthorId, @Price) RETURNING id",
                new { book.Title, book.AuthorId, book.Price }
                );
            var newBook = _db.Connection.QueryFirst<Book>(
                @"SELECT 
                        id AS Id, 
                        title AS Title,
                        author_id AS AuthorId,
                        price AS Price
                        FROM shop.book
                        WHERE id=@insertedId",
                new { insertedId });
            
            return newBook;
        }

        public Book DeleteBook(Book book)
        {
            var deletedBook = _db.Connection.QueryFirstOrDefault<Book>(@"
                DELETE FROM shop.book
                WHERE title = @Title
                RETURNING
                         id AS Id, 
                         title AS Title,
                         author_id AS AuthorId,
                         price AS Price",
                        new { book.Title });

            return deletedBook;
        }

        public Book GetBookByTitle(string title)
        {
            var bookByTitle = _db.Connection.QueryFirstOrDefault<Book>(@"
                SELECT 
                        id AS Id, 
                        title AS Title,
                        author_id AS AuthorId,
                        price AS Price
                        FROM shop.book
                        WHERE title = @title",
                        new {title});

            return bookByTitle;
        }
    }
}
