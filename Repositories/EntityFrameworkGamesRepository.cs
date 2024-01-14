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
        dbContext.Games.Add(game);
        dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        dbContext.Games.Where(game=>game.Id==id)
                       .ExecuteDelete();
        
    }

    public Game? Get(int id)
    {
        return dbContext.Games.Find(id);
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Games.AsNoTracking().ToList();
    }

    public void Update(Game updatedGame)
    {
        dbContext.Update(updatedGame);
        dbContext.SaveChanges();
    }
}