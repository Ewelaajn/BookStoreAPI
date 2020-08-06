using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Repositories;
using BookStoreApi.Tests.Integration.DbTools;
using Dapper;
using FluentAssertions;
using NUnit.Framework;

namespace BookStoreApi.Tests.Integration.RepositoriesTests
{
    [TestFixture]
    public class BookRepositoryTest
    {
        private readonly IBookRepository _bookRepository;
        private readonly IDb _db;
        public BookRepositoryTest()
        {
            _db = new TestDb();
            _bookRepository = new BookRepository(_db);
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("One time set up, runs before all tests.");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("One time tear down, runs once after all tests.");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Set up, runs before every test.");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tear down, runs after every test.");
        }

        // testedMethodName_testCase_expectedResult 
        [Test]
        public void DbConnection_WorksCorrectly_ReturnsData()
        {
            var query = @"SELECT 1";

            int result = _db.Connection.QueryFirst<int>(query);

            int expectedResult = 1;

            // NUnit
            Assert.AreEqual(expectedResult, result);

            //FluentAssetions
            result.Should().Be(expectedResult);

        }
    }
}
