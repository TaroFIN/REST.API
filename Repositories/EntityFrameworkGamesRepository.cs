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

    public void Create(Game game)
    {
        dbContext.Game.Add(game);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Game.Where(game=>game.Id==id)
                       .ExecuteDelete();
                       
    }

    public Game? Get(int id)
    {
        return dbContext.Game.Find(id);
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Game.AsNoTracking().ToList();
    }

    public void Update(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        dbContext.SaveChanges();
    }
}