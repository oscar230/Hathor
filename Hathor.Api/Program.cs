using Flurl.Http.Configuration;
using Hathor.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// SQL
string databaseConnection = builder.Configuration.GetConnectionString("HathorConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(databaseConnection));

builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddScoped<DbService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
