using GameStore.api.Dtos;
using GameStore.Api.Dtos;

const string GetGameEndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
     new (
        1,
        "street fighter",
        "Fighting",
        11.44M,
        new DateOnly(1902,8,15)
     ),
        new (
        2,
        "fighter",
        "Fighting",
        132.44M,
        new DateOnly(1932,8,15)
     ),
        new (
        3,
        "Car Racing",
        "Fighting",
        31.44M,
        new DateOnly(2022,8,15)
     ),
];
// GET /games
app.MapGet("/games", () => games);

// GET /games/1
app.MapGet("/games/{id}",(int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

// POSt /games
app.MapPost("/games",(CreateGameDto newGame) =>
{
    GameDto game = new(
      games.Count + 1,
      newGame.Name,
      newGame.Genre,
      newGame.Price,
      newGame.ReleaseDate
    );

    games.Add(game);
    return Results.CreatedAtRoute(GetGameEndpointName, new {id=game.Id},game);
});

app.Run();









