using System.Web;

namespace WebApi.Helpers
{
    public static class HttpHelper
    {
        public static string UrlEncode(string str) => HttpUtility.UrlEncode(str);
    }
}
