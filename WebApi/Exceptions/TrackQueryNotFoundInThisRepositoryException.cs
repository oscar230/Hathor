using HathorCommon.Models;

namespace WebApi.Exceptions
{
    public class TrackQueryNotFoundInThisRepositoryException : Exception, IUserExceptions
    {
        private string _query;
        private Repository _repository;

        public TrackQueryNotFoundInThisRepositoryException(string? query, Repository repository) : base($"Query: {query} found no tracks, in repository: {repository.DisplayName}.")
        {
            _query = query ?? string.Empty;
            _repository = repository;
        }

        public string UserMessage => $"No tracks from query {_query} found in the repository {_repository.DisplayName}.";
    }
}
