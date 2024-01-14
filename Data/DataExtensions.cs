using Microsoft.EntityFrameworkCore;
using REST.API.Repositories;

namespace REST.API.Data;

public static class DataExtensions
{
    public static void InitialDB(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration["ConnectionStrings:GameStoreContext"];
        services.AddSqlServer<GameStoreContext>(connString)
                .AddScoped<IGameRepository, EntityFrameworkGamesRepository>();;

        return services;
    }
}