using WebApi.Models;
using WebApi.Services;

namespace WebApi.Exceptions
{
    public class TrackQueryNotFoundInAnyRepositoryException : Exception, IUserExceptions
    {
        private string _query;
        private List<IRepository> _repositories;

        public TrackQueryNotFoundInAnyRepositoryException(string? query, List<ITrackRepositoryService> repositoryServices) : this(query, repositoryServices.Select(service => service.Repository).ToList()) { }

        public TrackQueryNotFoundInAnyRepositoryException(string? query, List<IRepository> repositories) : base($"Query: {query} found no tracks at all, in any repository (number of repositories {repositories.Count}).")
        {
            _query = query ?? string.Empty;
            _repositories = repositories;
        }

        private string PrintRepositories()
        {
            string s = new("");
            var c = _repositories.Count;
            foreach (var repository in _repositories)
            {
                if (c > 1)
                {
                    s = $"{s}, {repository.DisplayName}";
                }
                else if (c > 0)
                {
                    s = $"{s} nor {repository.DisplayName}";
                }
                c--;
            }
            return s;
        }

        public string UserMessage => $"No tracks from query {_query} found in either repository {PrintRepositories()}.";
    }
}
