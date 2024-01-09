using REST.API.Entities;
using REST.API.Repositories;
namespace REST.API.Endpoints;


public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();
        InMemGameRepository repository = new();

        group.MapGet("/", () => repository.GetAll());

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = repository.Get(id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndPointName);

        group.MapPost("/", (Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existGame = repository.Get(id);

            if (existGame is null) return Results.NotFound();

            existGame.Name = updatedGame.Name;
            existGame.Genre = updatedGame.Genre;
            existGame.ReleaseDate = updatedGame.ReleaseDate;

            repository.Update(existGame);
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? Game = repository.Get(id);

            if (Game is not null) repository.Delete(id);
            return Results.NoContent();
        });
        return group;
    }
}
