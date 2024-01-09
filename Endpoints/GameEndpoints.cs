using REST.API.Entities;
using REST.API.Repositories;
namespace REST.API.Endpoints;


public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", (IGameRepository repository) => repository.GetAll());

        group.MapGet("/{id}", (IGameRepository repository, int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndPointName);

        group.MapPost("/", (IGameRepository repository, Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (IGameRepository repository, int id, Game updatedGame) =>
        {
            Game? existGame = repository.Get(id);

            if (existGame is null) return Results.NotFound();

            existGame.Name = updatedGame.Name;
            existGame.Genre = updatedGame.Genre;
            existGame.ReleaseDate = updatedGame.ReleaseDate;

            repository.Update(existGame);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGameRepository repository, int id) =>
        {
            Game? Game = repository.Get(id);

            if (Game is not null) repository.Delete(id);
            return Results.NoContent();
        });
        return group;
    }
}
