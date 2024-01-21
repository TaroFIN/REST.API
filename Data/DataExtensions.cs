using Microsoft.EntityFrameworkCore;
using REST.API.Repositories;

namespace REST.API.Data;

public static class DataExtensions
{
    public static async Task InitialDB(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await DbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString)
                .AddScoped<IGameRepository, EntityFrameworkGamesRepository>()
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();
                

        return services;
    }
}