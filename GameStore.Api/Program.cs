using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

List<GameDto> games = new List<GameDto>
    {
        new GameDto(1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
        new GameDto(2, "Final Fantasy XIV", "Roleplaying", 34.99M, new DateOnly(2010, 9, 30)),
        new GameDto(3, "Farcry 3", "Arcade", 49.99M, new DateOnly(2013, 4, 23))
    };

//getAll
app.MapGet("games", () => games);

// getById
app.MapGet("games/{id}", (int id) =>
{
    GameDto? game = games.Find(game => game.Id == id);
    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName(GetGameEndPointName);

// create
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});

// update
app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{
    var index = games.FindIndex(game => game.Id == id);
    if (index == -1)
    {
        Results.NotFound();
    }
    games[index] = new GameDto(id, updatedGame.Name, updatedGame.Genre, updatedGame.Price, updatedGame.ReleaseDate);
    return Results.NoContent();
});

//delete
app.MapDelete("games/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id == id);
    return Results.NoContent();
});

app.MapGet("/", () => "Hello World!");

app.Run();
