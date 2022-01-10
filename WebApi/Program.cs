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
            builder.Services.AddScoped<ITrackProvider, SliderTrackProviderService>();
            builder.Services.AddScoped<ITrackProvider, BtdigTrackProviderService>();

            var app = builder.Build();

            app.MapGet("/", () => "Hathor!");

            app.Run();
        }
    }
}