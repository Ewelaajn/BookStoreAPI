using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BookStoreApi.Tests.Integration.DbManager;
using NUnit.Framework;

namespace BookStoreApi.Tests.Integration
{
    [SetUpFixture]
    public class SetUpDatabase
    {
        private readonly PostgresManager _postgresManager;
        public SetUpDatabase()
        {
            _postgresManager = new PostgresManager();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _postgresManager.CreateTestDb();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _postgresManager.DropTestDb();
        }
    }
}
