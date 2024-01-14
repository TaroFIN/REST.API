using Microsoft.EntityFrameworkCore;

namespace REST.API.Data;

public static class DataExtensions
{
    public static void InitialDB(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var DbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        DbContext.Database.Migrate();
    }
}