using System.ComponentModel.DataAnnotations;

namespace REST.API.Dtos;

public record BookDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime PublishDate
);

public record CreateBookDto(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(0,1000)]decimal Price,
    DateTime PublishDate
);

public record UpdateBookDto(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(0,1000)]decimal Price,
    DateTime PublishDate
);