using Microsoft.EntityFrameworkCore;
using REST.API.Data;
using REST.API.Entities;

namespace REST.API.Repositories;

public class EntityFrameworkGamesRepository : IGameRepository
{
    private readonly GameStoreContext dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task CreateAsync(Game game)
    {
        dbContext.Game.Add(game);
        dbContext.SaveChanges();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        await dbContext.Game.Where(game=>game.Id==id)
                       .ExecuteDeleteAsync();
                       
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.Game.FindAsync(id);
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Game.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }
}