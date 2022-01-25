using System.Linq;
using System.Runtime.Serialization;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Exceptions
{
    public class TrackQueryNotFoundException : Exception, IUserExceptions
    {
        private string _query;
        private List<IRepository> _repositories;

        public TrackQueryNotFoundException(string query, List<ITrackRepositoryService> repositoryServices) : this(query, repositoryServices.Select(service => service.repository).ToList()) { }

        public TrackQueryNotFoundException(string query, List<IRepository> repositories) : base($"Query: {query} found no tracks.")
        {
            _query = query;
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
