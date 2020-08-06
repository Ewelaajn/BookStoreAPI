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
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public TestDb()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = _configuration["DbSettings:ConnectionString"];
        }
        public NpgsqlConnection Connection => new NpgsqlConnection(_connectionString);
    }
}
