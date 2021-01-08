using System.Collections.Generic;
using System.Linq;
using Autofac;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using Dapper;
using FluentAssertions;
using Npgsql;
using NUnit.Framework;

namespace BookStoreApi.Tests.Integration.RepositoriesTests
{
    [TestFixture]
    public class BookRepositoryTest : RepositoryTest
    {
        [SetUp]
        public void SetUp()
        {
            BookRepository = Container.Resolve<IBookRepository>();
        }

        // testedMethodName_testCase_expectedResult 
        [Test]
        public void DbConnection_WorksCorrectly_ReturnsData()
        {
            var query = @"SELECT 1";

            var result = Db.Connection.QueryFirst<int>(query);

            var expectedResult = 1;

            // NUnit
            Assert.AreEqual(expectedResult, result);

            //FluentAssetions
            result.Should().Be(expectedResult);
        }

        [Test]
        public void GetAllBooks_ThereAreBooksInDataBase_ReturnsAllBooks()
        {
            var expectedResult = AllBooks;
            var result = BookRepository.GetAllBooks();

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void GetAllBooks_ThereAreNoBooks_ReturnsEmptyCollection()
        {
            var deleteAllBooksQuery = @"
            DELETE FROM shop.order_book;
            DELETE FROM shop.book;";

            Db.Connection.Execute(deleteAllBooksQuery);

            var result = BookRepository.GetAllBooks();

            result.Should().BeEmpty();
        }

        [Test]
        [TestCase("IT")]
        public void GetBookByTitle_TitleOfBookExists_ReturnsBook(string title)
        {
            var expectedResult = AllBooks.Single(book => book.Title.Equals(title));
            var result = BookRepository.GetBookByTitle(title);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase("Test title that is not in database")]
        [TestCase("")]
        [TestCase(null)]
        public void GetBookByTitle_TitleOfBookDoesNotExists_ReturnsNull(string title)
        {
            var result = BookRepository.GetBookByTitle(title);

            result.Should().BeNull();
        }

        [Test]
        [TestCase("NewTitle", 1, 30)]
        public void CreateBook_ValidBookSuppliedAsParameter_CreatesAndReturnsNewBook
            (string title, int authorId, decimal price)
        {
            var validInput = new Book
            {
                Title = title,
                AuthorId = authorId,
                Price = price
            };

            var highestCurrentBookId = AllBooks.Max(book => book.Id);

            var expectedResult = new Book
            {
                Title = title,
                AuthorId = authorId,
                Price = price,
                Id = highestCurrentBookId + 1
            };

            var result = BookRepository.CreateBook(validInput);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        [TestCase("IT", 1, 10)]
        // PostgresCode23505 unique constraint valuation
        public void CreateBook_TitleAlreadyExistsInDatabase_PostgresExceptionCode23505(string title, int authorId,
            decimal price)
        {
            var invalidBook = new Book
            {
                Title = title,
                AuthorId = authorId,
                Price = price
            };

            FluentActions.Invoking(() => BookRepository.CreateBook(invalidBook))
                .Should().Throw<PostgresException>()
                .Where(exception => int.Parse(exception.SqlState) == 23505);
        }

        private List<Book> AllBooks => new List<Book>
        {
            new Book
            {
                Id = 1,
                AuthorId = 1,
                Title = "Romeo and Juliet",
                Price = 30.00m
            },
            new Book
            {
                Id = 2,
                AuthorId = 2,
                Title = "Murder on the Orient Express",
                Price = 25.00m
            },
            new Book
            {
                Id = 3,
                AuthorId = 3,
                Title = "Flatland",
                Price = 35.00m
            },
            new Book
            {
                Id = 4,
                AuthorId = 4,
                Title = "The Cossacks",
                Price = 28.00m
            },
            new Book
            {
                Id = 5,
                AuthorId = 5,
                Title = "IT",
                Price = 32.00m
            }
        };
    }
}