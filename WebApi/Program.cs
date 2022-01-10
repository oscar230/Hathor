using WebApi.Services;

namespace WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Services.AddScoped<ITrackProviderService, SliderTrackProviderService>();
            builder.Services.AddScoped<ITrackProviderService, BtdigTrackProviderService>();

            var app = builder.Build();

            app.MapGet("/", () => "Hathor!");

            app.Run();
        }
    }
}