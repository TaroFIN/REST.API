using System.ComponentModel.DataAnnotations;

namespace REST.API.Dtos;

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate
);

public record CreateGameDto(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(0,1000)]decimal Price,
    DateTime ReleaseDate
);

public record UpdateGameDto(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(0,1000)]decimal Price,
    DateTime ReleaseDate
);