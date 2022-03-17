using HathorCommon.Helpers;
using WebApi.Helpers;

namespace WebApi.Services
{
    public class UserAgentService
    {
        public const string DEFAULT_USER_AGENT = "Mozilla/1.22 (compatible; MSIE 2.0; Windows 3.1)";
        private const string STORED_USER_AGENT_PATH = "Resources\\UserAgents\\";
        private readonly ILogger<UserAgentService> _logger;
        private readonly IEnumerable<string> _userAgents;

        public UserAgentService(ILogger<UserAgentService> logger)
        {
            _logger = logger;
            _userAgents = LoadStoredUserAgents();
        }

        public string RandomOne(IEnumerable<string>? excludeThese = null)
        {
            IEnumerable<string> userAgents = _userAgents;
            if (excludeThese != null)
            {
                userAgents = _userAgents.Where(ua => !excludeThese.Contains(ua));
            }
            return EnumerableHelper.RandomOne(userAgents);
        }

        private List<string> LoadStoredUserAgents()
        {
            var userAgents = new List<string>();
            var directory = new DirectoryInfo(STORED_USER_AGENT_PATH);
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension.Equals(".txt") && file.Length > 0)
                {
                    var lines = File.ReadAllLines(file.FullName);
                    foreach (var line in lines)
                    {
                        userAgents.Add(line);
                    }
                    _logger.LogDebug($"Loaded file {file.Name} (with {lines.Count()} user agents).");
                }
                else
                {
                    _logger.LogWarning($"File {file.Name} should not be here.");
                }
            }
            if (userAgents.Count() == 0)
            {
                _logger.LogWarning($"Could not load any user agents. Will load default user agent {DEFAULT_USER_AGENT}");
                userAgents.Add(DEFAULT_USER_AGENT);
            }
            return userAgents;
        }
    }
}
