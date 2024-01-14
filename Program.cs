using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using REST.API.Data;
using REST.API.Endpoints;
using REST.API.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGameRepository, InMemGameRepository>();

var connString = builder.Configuration["ConnectionStrings:GameStoreContext"];
builder.Services.AddSqlServer<GameStoreContext>(connString);
var app = builder.Build();

app.Services.InitialDB();

app.MapGamesEndpoints();

app.Run();
