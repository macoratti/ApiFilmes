using ApiFilmes.Services;
using Refit;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var authToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJiNTZjMmZmNjc5ODg1ZGU1NTg0NTE5Mzc3M2Y0ZjBiMCIsIm5iZiI6MTcyNjU3ODM1NS43NTI0NDYsInN1YiI6IjY2ZTk3ZDdiODJmZjg3M2Y3ZDFlYjlmZCIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.8rDUgRPoU8rBASU3yFZP4kUy2UhNxUNbbHaQqXDJGMw";

var refitSettings = new RefitSettings()
{
    AuthorizationHeaderValueGetter = (rq, ct) => Task.FromResult(authToken),
   
    ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true // Ignora maiúsculas/minúsculas
    })
};

builder.Services
    .AddRefitClient<ITmdb>(refitSettings)
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.themoviedb.org/3"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

