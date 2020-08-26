using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Repositories;
using BookStoreApi.Tests.Integration.DbManager;
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
        private readonly DbManager.PostgresManager _postgresManager;
        public BookRepositoryTest()
        {
            _db = new TestDb();
            _bookRepository = new BookRepository(_db);
            _postgresManager = new PostgresManager();
        }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _postgresManager.SetUpSchema();
        }

        [TearDown]
        public void TearDown()
        {
            _postgresManager.ResetSchema();
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
