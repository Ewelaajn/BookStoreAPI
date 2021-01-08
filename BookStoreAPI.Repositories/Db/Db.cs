using BookStoreAPI.Repositories.DbConnection;
using BookStoreAPI.Repositories.Settings;
using Microsoft.Extensions.Options;
using Npgsql;

namespace BookStoreAPI.Repositories.Db
{
    public class Db : IDb
    {
        private readonly DbSettings _dbSettings;

        public Db(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public NpgsqlConnection Connection => new NpgsqlConnection(_dbSettings.ConnectionString);
    }
}