var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var random = new Random();

app.MapGet("/random-number", () =>
{
    return random.Next(0,1000);
});

app.Run();

