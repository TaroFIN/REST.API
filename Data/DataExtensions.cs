using Microsoft.EntityFrameworkCore;
using REST.API.Repositories;

namespace REST.API.Data;

public static class DataExtensions
{
    public static async Task InitialDB(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var GameStoreDbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await GameStoreDbContext.Database.MigrateAsync();

        var BookStoreDbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();
        await BookStoreDbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString)
                .AddScoped<IGameRepository, EntityFrameworkGamesRepository>()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c=>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Description="This is my first API document project.",
                        Title="Games"
                    });
                });
        services.AddSqlServer<BookStoreContext>(connString)
                .AddScoped<IBookRepository, EntityFrameworkBooksRepository>()
                .AddEndpointsApiExplorer();


        return services;
    }
}