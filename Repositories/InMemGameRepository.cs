using REST.API.Entities;

namespace REST.API.Repositories;


public class InMemGameRepository : IGameRepository
{
    private readonly List<Game> games = new()
    {
        new Game()
        {
            Id=1,
            Name="Street Fighter II",
            Genre="Action",
            ReleaseDate=new DateTime(2023,12,31,00,00,00)
        }
    };

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}