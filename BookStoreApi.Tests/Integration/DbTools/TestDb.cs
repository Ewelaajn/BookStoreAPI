using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Text;
using BookStoreAPI.Repositories.DbConnection;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace BookStoreApi.Tests.Integration.DbTools 
{
    public class TestDb : IDb
    {
        private TestSettings Settings { get; }
        public TestDb()
        {
            Settings = TestSettings.MapSettings();
        }
        public NpgsqlConnection Connection => new NpgsqlConnection(Settings.DbSettings.ConnectionString);
    }
}
