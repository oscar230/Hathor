using WebApi.Models;

namespace WebApi.Exceptions
{
    public class TrackQueryNotFoundInThisRepositoryException : Exception, IUserExceptions
    {
        private string _query;
        private IRepository _repository;

        public TrackQueryNotFoundInThisRepositoryException(string? query, IRepository repository) : base($"Query: {query} found no tracks, in repository: {repository.DisplayName}.")
        {
            _query = query ?? string.Empty;
            _repository = repository;
        }

        public string UserMessage => $"No tracks from query {_query} found in the repository {_repository.DisplayName}.";
    }
}
