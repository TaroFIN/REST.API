using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using REST.API.Data;
using REST.API.Endpoints;
using REST.API.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitialDB();

app.UseSwagger();
app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        //c.DocumentTitle = "Games";
    }
);
app.MapGamesEndpoints();

app.Run();
