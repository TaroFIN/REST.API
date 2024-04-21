using Microsoft.EntityFrameworkCore;
using REST.API.Data;
using REST.API.Entities;

namespace REST.API.Repositories;

public class EntityFrameworkBooksRepository : IBookRepository
{
    private readonly BookStoreContext BookStoredbContext;

    public EntityFrameworkBooksRepository(BookStoreContext dbContext)
    {
        this.BookStoredbContext = dbContext;
    }

    public async Task CreateAsync(Book book)
    {
        BookStoredbContext.Book.Add(book);
        BookStoredbContext.SaveChanges();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        await BookStoredbContext.Book.Where(game=>game.Id==id)
                       .ExecuteDeleteAsync();
                       
    }

    public async Task<Book?> GetAsync(int id)
    {
        return await BookStoredbContext.Book.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await BookStoredbContext.Book.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Book updatedBook)
    {
        BookStoredbContext.Update(updatedBook);
        await BookStoredbContext.SaveChangesAsync();
    }
}