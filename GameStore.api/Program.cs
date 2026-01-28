using GameStore.Api.Dtos;

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
app.MapGet("/games/{id}",(int id) => games.Find(game => game.Id == id));

// POSt /games

app.Run();









