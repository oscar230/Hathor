using Hathor.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Hathor.Web.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ValidateContextConnection(this WebApplication webApplication)
        {
            using IServiceScope scope = webApplication.Services.CreateScope();
            using HathorContext context = scope.ServiceProvider.GetRequiredService<HathorContext>();
            context.Database.OpenConnection();
            context.Database.CloseConnection();
            return webApplication;
        }
    }
}
