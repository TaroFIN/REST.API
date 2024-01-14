using REST.API.Entities;

namespace REST.API.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game? Get(int id);
        void Create(Game game);
        void Update(Game updatedGame);
        void Delete(int id);
    }
}