using Microsoft.Data.Sqlite;
using System.Data;

namespace BookstoreAPI.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionString = this._configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqliteConnection(connectionString);
    }
}
