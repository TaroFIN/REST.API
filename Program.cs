using REST.API.Data;
using REST.API.Endpoints;
using REST.API.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository, InMemGameRepository>();

var connString = builder.Configuration["ConnectionString:GameStoreContext"];
builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build();
app.MapGamesEndpoints();

app.Run();
