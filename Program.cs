using REST.API.Endpoints;
using REST.API.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository, InMemGameRepository>();
var app = builder.Build();
app.MapGamesEndpoints();

app.Run();
