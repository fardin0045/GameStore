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
app.MapGet("/games/{id}", (int id) =>
{
   var game =games.Find(game => game.Id == id);
   return game is null ? Results.NoContent() : Results.Ok(game);
}).WithName(GetGameEndpointName);

// POSt /games
app.MapPost("/games", (CreateGameDto newGame) =>
{
   GameDto game = new(
     games.Count + 1,
     newGame.Name,
     newGame.Genre,
     newGame.Price,
     newGame.ReleaseDate
   );

   games.Add(game);
   return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
});

//PUT /games/1
app.MapPut("/games/{id}",(int id, UpdateGameDto updatedGame )=>
{
   var index = games.FindIndex(game => game.Id == id);
   if (index == -1)
   {
      return Results.NotFound();
   }

   games[index] = new GameDto(
      id,
      updatedGame.Name,
      updatedGame.Genre,
      updatedGame.Price,
      updatedGame.ReleaseDate
   );
   return Results.NoContent();
});

// DELETE /games/1
app.MapDelete("/games/{id}",(int id) =>
{
   games.RemoveAll(game => game.Id == id);
   return Results.NoContent();
});

app.Run();









