using REST.API.Dtos;

namespace REST.API.Entities;

public static class GameExtensions
{
    public static GameDto AsDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate
        );
    }
}