namespace WebApi.Services
{
    public interface IUserAgentService
    {
        string RandomOne(IEnumerable<string>? excludeThese = null);
    }
}
