
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BookStoreAPI.Repositories.Db;
using Dapper;
using Npgsql;

namespace BookStoreApi.Tests.Integration.DbManager
{
    public class PostgresManager
    {
        private TestSettings Settings { get; }
        private readonly string _baseConnectionString;
        private readonly string _postgresConnectionString;
        private readonly string _testDatabaseConnectionString;
        private string _schema;
        private readonly string _host;
        private readonly string _db;
        private readonly string _user;
        private readonly string _pswd; 
        public PostgresManager()
        {
            Settings = TestSettings.MapSettings();

            _host = Settings.DbManager.Host;
            _db = Settings.DbManager.DataBase;
            _user = Settings.DbManager.Username;
            _pswd = Settings.DbManager.Password;

            _baseConnectionString = $"Host={_host};Username={_user};Password={_pswd};";
            _postgresConnectionString = $"{_baseConnectionString};Database=postgres";
            _testDatabaseConnectionString = $"{_baseConnectionString};Database={_db}";

        }
        public void CreateTestDb()
        {
            using (var connection = new NpgsqlConnection(_postgresConnectionString))
            {
                connection.Execute(PostgresManagerQueries.CreateDb, 
                                    new
                                    {
                                        @host = _host,
                                        @database = _db,
                                        @user = _user,
                                        @password = _pswd
                                    });
            }
        }

        public void DropTestDb()
        {
            using (var connection = new NpgsqlConnection(_postgresConnectionString))
            {
                connection.Execute(PostgresManagerQueries.DropDb,
                                   new
                                                                {
                                                                    @database = _db,
                                                                    @user = _user,
                                                                    @password = _pswd
                                                                });
            }
        }

        public void BuildSchema()
        {
            var dbupDir = Settings.DbManager.DbupFolderName;

            var queries = new List<string>();
            var fileNames =
                Directory.EnumerateFiles(dbupDir).OrderBy(fileName => fileName).ToList();

            foreach (var fileName in fileNames)
            {
                string content = File.ReadAllText(fileName);
                queries.Add(content);
            }

            _schema = string.Join("\n", queries);
        }

        public void SetUpSchema()
        {
            if(string.IsNullOrEmpty(_schema))
                BuildSchema();

            using (var connection = new NpgsqlConnection(_testDatabaseConnectionString))
            {
                connection.Execute(_schema);
            }
        }

        public void ResetSchema()
        {
            if (String.IsNullOrEmpty(_schema))
                BuildSchema();

            using (var connection = new NpgsqlConnection(_testDatabaseConnectionString))
            {
                connection.Execute(PostgresManagerQueries.ResetSchema);
                connection.Execute(_schema);
            }
        }

        public void FillDbWithTestData()
        {

        }
    }
}
