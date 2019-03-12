using System.Data;
using System.Data.SqlClient;

namespace ZeroApp.ForecastTracker.Service.Infrastructure.DapperDataAccess
{
    public abstract class DapperBaseRepository
    {
        private readonly string _connectionString;

        protected DapperBaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected virtual IDbConnection CreateNewConnection()
            => new SqlConnection(_connectionString);
    }
}
