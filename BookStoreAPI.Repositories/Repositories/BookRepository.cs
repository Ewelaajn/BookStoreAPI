using System;
using System.Collections.Generic;
using System.Data;
using BookStoreAPI.Repositories.Db;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
using Dapper;

namespace BookStoreAPI.Repositories.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDb _db;

        // Constructor is a recipe for making a object instance
        public BookRepository(IDb db)
        {
            _db = db;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var resultConnectionBook = _db.Connection.Query<Book>
                (BookQueries.GetAllBooks);

            return resultConnectionBook;
        }

        public Book GetBookByTitle(string title)
        {
            var bookByTitle = _db.Connection.QueryFirstOrDefault<Book>
                (BookQueries.GetBookByTitle, new {title});

            return bookByTitle;
        }

        public Book CreateBook(Book book)
        {
            var insertedId = _db.Connection.QueryFirst<int>
                (BookQueries.CreateBook, new {book.Title, book.AuthorId, book.Price});
            var newBook = _db.Connection.QueryFirst<Book>
                (BookQueries.GetBookById, new {id = insertedId});

            return newBook;
        }

        public Book UpdateBook(string currentTitle, string newTitle, int newAuthorId, decimal newPrice)
        {
            var updatedBook = _db.Connection.QueryFirstOrDefault<Book>(
                BookQueries.UpdateBook, new {title = currentTitle, newTitle, newAuthorId, newPrice});

            return updatedBook;
        }

        public Book DeleteBook(Book book)
        {
            var connection = _db.Connection;
            connection.Open();

            using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    _db.Connection.Execute
                        (BookQueries.DeleteBookFromOrders, new {book_id = book.Id}, transaction);

                    var deletedBook = _db.Connection.QueryFirstOrDefault<Book>
                        (BookQueries.DeleteBookByTitle, new {book.Title}, transaction);

                    transaction.Commit();
                    return deletedBook;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}