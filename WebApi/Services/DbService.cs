using System.Data;
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
            _connection.Open();
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
            const string query = "INSERT INTO SliderTrack (SliderID, Duration, FullTitle, Url, ExtraInformation) VALUES (@SliderID, @Duration, @FullTitle, @Url, @ExtraInformation);";
            var command = new SqlCommand(query, _connection);

            command.Parameters.Add("@SliderID", SqlDbType.VarChar, 20);
            command.Parameters["@SliderID"].Value = sliderTrack.SliderID;

            command.Parameters.Add("@Duration", SqlDbType.Int);
            command.Parameters["@Duration"].Value = Convert.ToInt32(sliderTrack.Duration);

            command.Parameters.Add("@FullTitle", SqlDbType.VarChar, 200);
            command.Parameters["@FullTitle"].Value = sliderTrack.FullTitle;

            command.Parameters.Add("@Url", SqlDbType.VarChar, 250);
            command.Parameters["@Url"].Value = sliderTrack.Url;

            command.Parameters.Add("@ExtraInformation", SqlDbType.Bit);
            command.Parameters["@ExtraInformation"].Value = sliderTrack.ExtraInformation == null ? 0 : 1;
            
            return command;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
