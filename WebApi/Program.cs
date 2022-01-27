using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<IUserAgentService, UserAgentService>();
builder.Services.AddScoped<ISliderTrackRepositoryService, SliderTrackRepositoryService>();
builder.Services.AddHttpClient<ISliderTrackRepositoryService, SliderTrackRepositoryService>("SliderHttpClient", configureClient =>
{
    configureClient.Timeout = new TimeSpan(0, 1, 30); // 1 minute and 30 seconds timeout
    configureClient.DefaultRequestHeaders.Add("User-Agent", "WebApi");
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
