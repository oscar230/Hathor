using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<IUserAgentService, UserAgentService>();
builder.Services.AddSingleton<ISliderTrackRepositoryService, SliderTrackRepositoryService>();
builder.Services.AddHttpClient(SliderTrackRepositoryService.PROXIED_SLIDER_HTTP_CLIENT_NAME, configureClient =>
{
    configureClient.BaseAddress = new Uri("https://slider.wonky.se/");
    configureClient.Timeout = new TimeSpan(0, 0, 30); // 30s
    configureClient.DefaultRequestHeaders.Add("User-Agent", "WebApi");
});
builder.Services.AddHttpClient(SliderTrackRepositoryService.DIRECT_SLIDER_HTTP_CLIENT_NAME, configureClient =>
{
    configureClient.BaseAddress = new Uri("https://slider.kz/");
    configureClient.Timeout = new TimeSpan(0, 3, 0); // 3m
    configureClient.DefaultRequestHeaders.Add("User-Agent", UserAgentService.DEFAULT_USER_AGENT);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
