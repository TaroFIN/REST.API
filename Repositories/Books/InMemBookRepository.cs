using REST.API.Entities;

namespace REST.API.Repositories;


public class InMemBookRepository : IBookRepository
{
    private readonly List<Book> books = new();

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await Task.FromResult(books);
    }

    public async Task<Book?> GetAsync(int id)
    {
        return await Task.FromResult(books.Find(book => book.Id == id));
    }

    public async Task CreateAsync(Book book)
    {
        book.Id = books.Max(book => book.Id) + 1;
        books.Add(book);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Book updatedBook)
    {
        var index = books.FindIndex(book => book.Id == updatedBook.Id);
        books[index] = updatedBook;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        var index = books.FindIndex(game => game.Id == id);
        books.RemoveAt(index);
        await Task.CompletedTask;
    }
}