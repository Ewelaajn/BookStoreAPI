using Microsoft.Extensions.Configuration;

namespace BookStoreApi.Tests
{
    public class TestSettings
    {
        public DbSettings DbSettings { get; set; }
        public DbManager DbManager { get; set; }

        public static TestSettings MapSettings()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var settings = new TestSettings();
            configuration.Bind(settings);

            return settings;
        }
    }

    public class DbSettings
    {
        public string ConnectionString { get; set; }
    }

    public class DbManager
    {
        public string DataBase { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DbupFolderName { get; set; }
        public string TestQueriesFileLocation { get; set; }
    }
}