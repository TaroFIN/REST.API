using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using REST.API.Data;
using REST.API.Endpoints;
using REST.API.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);
var app = builder.Build();

app.Services.InitialDB();

app.MapGamesEndpoints();

app.Run();
