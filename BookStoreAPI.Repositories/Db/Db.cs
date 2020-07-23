using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
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
        public NpgsqlConnection Connect()
        {
            return new NpgsqlConnection(_dbSettings.ConnectionString);
        }
    }
}
