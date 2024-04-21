using REST.API.Dtos;
using REST.API.Entities;
using REST.API.Repositories;
namespace REST.API.Endpoints;


public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", async (IGameRepository repository) => (await repository.GetAllAsync()).Select(game=>game.AsDto()));

        group.MapGet("/v1/{id}", async(IGameRepository repository, int id) =>
        {
            Game? game = await repository.GetAsync(id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        }).WithName(GetGameEndPointName);

        group.MapPost("/", async(IGameRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate
            };
            await repository.CreateAsync(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/v1/{id}", async(IGameRepository repository, int id, GameDto updatedGameDto) =>
        {
            Game? existGame = await repository.GetAsync(id);

            if (existGame is null) return Results.NotFound();

            existGame.Name = updatedGameDto.Name;
            existGame.Genre = updatedGameDto.Genre;
            existGame.ReleaseDate = updatedGameDto.ReleaseDate;

            await repository.UpdateAsync(existGame);
            return Results.NoContent();
        });

        group.MapDelete("/v1/{id}", async(IGameRepository repository, int id) =>
        {
            Game? Game = await repository.GetAsync(id);

            if (Game is not null) await repository.DeleteAsync(id);
            return Results.NoContent();
        });
        return group;
    }
}
