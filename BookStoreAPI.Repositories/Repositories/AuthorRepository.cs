using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
using Dapper;

namespace BookStoreAPI.Repositories.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDb _db;

        public AuthorRepository(IDb db)
        {
            _db = db;
        }

        public Author CreateAuthor(string firstName, string lastName)
        {
            var id = _db.Connection.QueryFirst<int>
                (AuthorQueries.CreateAuthor, new {first_name = firstName, last_name = lastName});

            var author = _db.Connection.QueryFirst<Author>
                (AuthorQueries.GetAuthorById, new {id});

            return author;
        }

        public Author GetAuthor(string firstName, string lastName)
        {
            var author = _db.Connection.QueryFirstOrDefault<Author>
                (AuthorQueries.GetAuthor, new {first_name = firstName, last_name = lastName});

            return author;
        }

        public Author GetAuthorById(int authorId)
        {
            var author = _db.Connection.QueryFirst<Author>
                (AuthorQueries.GetAuthorById, new {id = authorId});

            return author;
        }

        public IEnumerable<Author> GetAuthorsByIds(List<int> ids)
        {
            var authors = _db.Connection.Query<Author>
                (AuthorQueries.GetAuthorsByIds, new {ids});

            return authors.ToList();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var authors = _db.Connection.Query<Author>
                (AuthorQueries.GetAllAuthors);

            return authors;
        }

        public Author UpdateAuthor(string currentFirstName, string currentLastName,
            string newFirstName, string newLastName)
        {
            var connection = _db.Connection;
            connection.Open();

            using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var updatedAuthor = _db.Connection.QueryFirstOrDefault<Author>
                    (AuthorQueries.UpdateAuthor,
                        new {currentFirstName, currentLastName, newFirstName, newLastName}, transaction);

                    transaction.Commit();
                    return updatedAuthor;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Author DeleteAuthor(string firstName, string lastName)
        {
            var connection = _db.Connection;
            connection.Open();

            using (var transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    var author = _db.Connection.QueryFirstOrDefault<Author>
                    (AuthorQueries.GetAuthor,
                        new {first_name = firstName, last_name = lastName}, transaction);

                    IEnumerable<Book> books = _db.Connection.Query<Book>
                    (BookQueries.GetBookByAuthorId,
                        new {author_id = author.Id}, transaction).ToList();

                    var booksIds = books.Select(bookId => bookId.Id).ToList();

                    _db.Connection.Execute
                    (BookQueries.DeleteBooksFromOrdersByIds,
                        new {book_id = booksIds}, transaction);

                    _db.Connection.Execute
                        (BookQueries.DeleteBookByAuthorId, new {author_id = author.Id}, transaction);

                    var deletedAuthor = _db.Connection.QueryFirstOrDefault<Author>
                    (AuthorQueries.DeleteAuthor,
                        new {first_name = firstName, last_name = lastName}, transaction);

                    transaction.Commit();
                    return deletedAuthor;
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