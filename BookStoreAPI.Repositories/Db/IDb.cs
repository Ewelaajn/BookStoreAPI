using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace BookStoreAPI.Repositories.DbConnection
{
    public interface IDb
    {
        NpgsqlConnection Connect();
    }
}
