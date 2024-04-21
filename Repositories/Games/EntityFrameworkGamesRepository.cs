using Microsoft.EntityFrameworkCore;
using REST.API.Data;
using REST.API.Entities;

namespace REST.API.Repositories;

public class EntityFrameworkGamesRepository : IGameRepository
{
    private readonly GameStoreContext GameStoredbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        this.GameStoredbContext = dbContext;
    }

    public async Task CreateAsync(Game game)
    {
        GameStoredbContext.Game.Add(game);
        GameStoredbContext.SaveChanges();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        await GameStoredbContext.Game.Where(game=>game.Id==id)
                       .ExecuteDeleteAsync();
                       
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await GameStoredbContext.Game.FindAsync(id);
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await GameStoredbContext.Game.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        GameStoredbContext.Update(updatedGame);
        await GameStoredbContext.SaveChangesAsync();
    }
}