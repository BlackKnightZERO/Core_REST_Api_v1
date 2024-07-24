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

app.MapGet("games", () => games);
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndPointName);
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

app.MapGet("/", () => "Hello World!");

app.Run();
