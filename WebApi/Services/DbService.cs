using System.Data;
using System.Data.SqlClient;

namespace Hathor.Api.Services
{
    public class DbService : IDisposable
    {
        const string CONNECTION_STRING_CONF_KEY = "DefaultConnection";
        private readonly ILogger<DbService> _logger;
        private readonly SqlConnection _connection;

        public DbService(ILogger<DbService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var connectionString = configuration.GetConnectionString(CONNECTION_STRING_CONF_KEY);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _logger.LogDebug($"DbService with connection at database {_connection.Database}.");
        }

        private string TransactionSqlExceptionLogString(SqlException ex) => $"Transaction failed, will roll back. Error: {ex}";

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
