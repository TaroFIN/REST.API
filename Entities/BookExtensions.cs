using REST.API.Dtos;

namespace REST.API.Entities;

public static class BookExtensions
{
    public static BookDto AsDto(this Book book)
    {
        return new BookDto(
            book.Id,
            book.Name,
            book.Genre,
            book.Price,
            book.PublishDate
        );
    }
}