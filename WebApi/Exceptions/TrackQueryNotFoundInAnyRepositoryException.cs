using Hathor.Api.Models;
using Hathor.Api.Services.TrackRepositoryServices;

namespace Hathor.Api.Exceptions
{
    public class TrackQueryNotFoundInAnyRepositoryException : Exception, IUserExceptions
    {
        private string _query;
        private List<Repository> _repositories;

        public TrackQueryNotFoundInAnyRepositoryException(string? query, List<ITrackRepositoryService> repositoryServices) : this(query, repositoryServices.Select(service => service.Repository).ToList()) { }

        public TrackQueryNotFoundInAnyRepositoryException(string? query, List<Repository> repositories) : base($"Query: {query} found no tracks at all, in any repository (number of repositories {repositories.Count}).")
        {
            _query = query ?? string.Empty;
            _repositories = repositories;
        }

        private string PrintRepositories()
        {
            string s = new("");
            var c = _repositories.Count;
            if (c > 1)
            {
                s = $"{s} either";
            }
            s = $"{s} repository";
            foreach (var repository in _repositories)
            {
                if (c > 1)
                {
                    s = $"{s}, {repository.DisplayName}";
                }
                else if (c > 0 && _repositories.Count > 1)
                {
                    s = $"{s} nor {repository.DisplayName}";
                }
                else
                {
                    s = $"{s} {repository.DisplayName}";
                }
                c--;
            }
            return s;
        }

        public string UserMessage => $"No tracks {(_query.Length > 0 ? $"from search query {_query}" : "from no search query" )} found in{PrintRepositories()}.";
    }
}
