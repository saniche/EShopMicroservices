using Ordering.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices()

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
