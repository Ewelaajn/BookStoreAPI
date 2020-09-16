using Npgsql;

namespace BookStoreAPI.Repositories.DbConnection
{
    public interface IDb
    {
        NpgsqlConnection Connection { get; }
    }
}