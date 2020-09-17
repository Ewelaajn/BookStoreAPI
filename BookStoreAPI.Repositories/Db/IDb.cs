using Npgsql;

namespace BookStoreAPI.Repositories.Db
{
    public interface IDb
    {
        NpgsqlConnection Connection { get; }
    }
}