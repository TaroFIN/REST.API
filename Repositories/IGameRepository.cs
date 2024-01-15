using REST.API.Entities;

namespace REST.API.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task <Game?> GetAsync(int id);
        Task CreateAsync(Game game);
        Task UpdateAsync(Game updatedGame);
        Task DeleteAsync(int id);
    }
}