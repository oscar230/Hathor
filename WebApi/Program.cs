namespace WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();
            var slider = new SliderFacade(app.Logger);

            app.MapGet("/", () => "Hathor!");
            app.MapGet("/search/{query:required}", (string query) => slider.Search(query));

            app.Run();
        }
    }
}