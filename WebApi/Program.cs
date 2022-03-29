using Flurl.Http.Configuration;
using WebApi.Services;
using WebApi.Services.PlaylistRepositoryServices;
using WebApi.Services.TrackRepositoryServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddSingleton<UserAgentService>();
builder.Services.AddScoped<SliderTrackRepositoryService>();
builder.Services.AddScoped<DbService>();
builder.Services.AddScoped<ThousandOnePlaylistRepositoryService>();

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
