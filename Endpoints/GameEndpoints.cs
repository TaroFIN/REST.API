using REST.API.Entities;
namespace REST.API.Endpoints;


public static class GameEndpoints
{
    const string GetGameEndPointName = "GetGame";

    static List<Game> games = new()
    {
    new Game()
    {
        Id=1,
        Name="Street Fighter II",
        Genre="Action",
        ReleaseDate=new DateTime(2023,12,31,00,00,00)
    }
    };
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);
            if (game is null) return Results.NotFound();
            return Results.Ok(games);
        }).WithName(GetGameEndPointName);

        group.MapPost("/", (Game game) =>
        {
            game.Id = games.Max(game => game.Id) + 1;
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame) =>
        {
            Game? existGame = games.Find(game => game.Id == id);

            if (existGame is null) return Results.NotFound();

            existGame.Name = updatedGame.Name;
            existGame.Genre = updatedGame.Genre;
            existGame.ReleaseDate = updatedGame.ReleaseDate;
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            Game? Game = games.Find(game => game.Id == id);

            if (Game is not null) games.Remove(Game);
            return Results.NoContent();
        });
        return group;
    }
}
