using Microsoft.EntityFrameworkCore;
using REST.API.Entities;

namespace REST.API.Data;


public class GameStoreContext : DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
    {

    }

    public DbSet<Game> Game => Set<Game>();

}