using REST.API.Entities;

namespace REST.API.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task <Book?> GetAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book updatedBook);
        Task DeleteAsync(int id);
    }
}