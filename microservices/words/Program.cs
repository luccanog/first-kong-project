var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var client = new HttpClient();

app.MapGet("/random-word", async () =>
 {
     var response = await client.GetFromJsonAsync<string[]>("https://random-word-api.herokuapp.com/word?number=1");

     return response is not null
     ? Results.Ok(response.First())
     : Results.NotFound();
 });

app.Run();

