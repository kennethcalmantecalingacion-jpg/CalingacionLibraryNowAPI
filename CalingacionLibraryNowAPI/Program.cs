var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Optional Swagger/OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Render provides PORT dynamically
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

app.Urls.Add($"http://+:{port}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
