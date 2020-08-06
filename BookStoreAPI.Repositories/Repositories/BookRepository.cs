using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
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
            var resultConnectionBook =_db.Connection.Query<Book>
                (BookQueries.GetAllBook);

            return resultConnectionBook;
        }

        public Book CreateBook(Book book)
        {
            var insertedId = _db.Connection.QueryFirst<int>
            (BookQueries.CreateBook, new { book.Title, book.AuthorId, book.Price });
            var newBook = _db.Connection.QueryFirst<Book>
                ( BookQueries.SelectBookById,new {id = insertedId });
            
            return newBook;
        }

        public Book DeleteBook(Book book)
        {
            var connection = _db.Connection;

            using(var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var idBookToDelete = _db.Connection.QueryFirst<int>
                        (BookQueries.SelectBookIdByTitle,new {book.Title}, transaction);

                    _db.Connection.Execute
                        (BookQueries.DeleteBookFromOrders,new {book_id = idBookToDelete}, transaction);

                    var deletedBook = _db.Connection.QueryFirstOrDefault<Book>
                    (BookQueries.DeleteBookByTitle,new {book.Title}, transaction);

                    transaction.Commit();
                    return deletedBook;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                
            }

            return null;
        }

        public Book GetBookByTitle(string title)
        {
            var bookByTitle = _db.Connection.QueryFirstOrDefault<Book>
            (BookQueries.GetBookByTitle, new {title});

            return bookByTitle;
        }
    }
}
