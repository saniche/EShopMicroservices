using Marten;

var builder = WebApplication.CreateBuilder(args);

//Add Services to DI
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Configure the  http request  pipeline
app.MapCarter();

app.Run();
