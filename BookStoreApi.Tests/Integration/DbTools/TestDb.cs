using BookStoreAPI.Repositories.DbConnection;
using Npgsql;

namespace BookStoreApi.Tests.Integration.DbTools
{
    public class TestDb : IDb
    {
        public TestDb()
        {
            Settings = TestSettings.MapSettings();
        }

        private TestSettings Settings { get; }
        public NpgsqlConnection Connection => new NpgsqlConnection(Settings.DbSettings.ConnectionString);
    }
}