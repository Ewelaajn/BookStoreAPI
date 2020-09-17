using Autofac;
using BookStoreAPI.Repositories.Db;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Repositories;
using BookStoreApi.Tests.Integration.DbManager;
using BookStoreApi.Tests.Integration.DbTools;
using NUnit.Framework;

namespace BookStoreApi.Tests.Integration.RepositoriesTests
{
    [TestFixture]
    public class RepositoryTest
    {
        [TearDown]
        public void TearDown()
        {
            _postgresManager.ResetSchema();
        }

        protected IBookRepository BookRepository;
        protected readonly IDb Db;
        private readonly PostgresManager _postgresManager;
        protected readonly IContainer Container;

        public RepositoryTest()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>();

            builder.RegisterType<TestDb>()
                .As<IDb>();

            builder.RegisterType<PostgresManager>();

            Container = builder.Build();

            Db = Container.Resolve<IDb>();
            _postgresManager = Container.Resolve<PostgresManager>();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _postgresManager.SetUpSchema();
        }
    }
}