using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Models;
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

        public Author GetAuthor(string firstName, string lastName)
        {
            var author = _db.Connection.QueryFirstOrDefault<Author>(@"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author
                WHERE  first_name = @firstName AND last_name = @lastName",
                new { firstName, lastName });

            return author;
        }

        public Author CreateAuthor(string firstName, string lastName)
        {
            int id = _db.Connection.QueryFirst<int>(@"
                INSERT INTO shop.author(first_name, last_name)
                VALUES (@firstName, @lastName) RETURNING id",
                new { firstName, lastName });

            var author = _db.Connection.QueryFirst<Author>(@"
                SELECT id AS Id,
                       first_name AS firstName,
                       last_name AS lastName
                FROM   shop.author
                WHERE id = @id",
                new { id });

            return author;
        }

        public Author GetAuthorById(int authorId)
        {
            var author = _db.Connection.QueryFirst<Author>(@"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author
                WHERE  id = @authorId",
                new { authorId });

            return author;
        }

        public IEnumerable<Author> GetAuthorsByIds(List<int> ids)
        {
            var authors = _db.Connection.Query<Author>(@"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author
                WHERE  id = ANY(@ids)",
               new { ids }) ;
            return authors;
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var authors = _db.Connection.Query<Author>(@"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author");

            return authors;
        }
    }
}     
