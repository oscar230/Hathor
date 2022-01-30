using System.Data.SqlClient;
using WebApi.Models.Slider;

namespace WebApi.Services
{
    public class DbService : IDbService
    {
        const string CONNECTION_STRING_CONF_KEY = "DefaultConnection";
        private readonly ILogger<DbService> _logger;
        private readonly SqlConnection _connection;

        public DbService(ILogger<DbService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var connectionString = configuration.GetConnectionString(CONNECTION_STRING_CONF_KEY);
            _connection = new SqlConnection(connectionString);
            _logger.LogDebug($"DbService with connection at database {_connection.Database}.");
        }

        public bool AddSliderTrack(SliderTrack sliderTrack)
        {
            var transaction = _connection.BeginTransaction("AddSliderTrack");
            var command = PrepareAddSliderTrackCommand(sliderTrack);
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                _logger.LogDebug($"Added track {sliderTrack.FullTitle} to database.");
            }
            catch (SqlException ex)
            {
                _logger.LogWarning(TransactionSqlExceptionLogString(ex));
                transaction.Rollback();
                return false;
            }
            return true;
        }

        public bool AddSliderTracks(IEnumerable<SliderTrack> sliderTracks)
        {
            var transaction = _connection.BeginTransaction("AddSliderTracks");
            var commands = new List<SqlCommand>();
            foreach (var sliderTrack in sliderTracks)
            {
                commands.Add(PrepareAddSliderTrackCommand(sliderTrack));
            }
            try
            {
                foreach (var command in commands)
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
                _logger.LogDebug($"Added {sliderTracks.Count()} tracks to database.");
            }
            catch (SqlException ex)
            {
                _logger.LogWarning(TransactionSqlExceptionLogString(ex));
                transaction.Rollback();
                return false;
            }
            return true;
        }

        private string TransactionSqlExceptionLogString(SqlException ex) => $"Transaction failed, will roll back. Error: {ex}";

        private SqlCommand PrepareAddSliderTrackCommand(SliderTrack sliderTrack)
        {
            var query = $"INSERT INTO Track (SliderID, Duration, FullTitle, Url, ExtraInformation) VALUES ({sliderTrack.SliderID}, {sliderTrack.Duration}, {sliderTrack.FullTitle}, {sliderTrack.Url}, {sliderTrack.ExtraInformation});";
            var command = new SqlCommand(query, _connection);
            return command;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
