using GameStore.api.Data;
using GameStore.api.Dtos;
using GameStore.api.EndPoints;
using GameStore.api.Models;
using GameStore.Api.Dtos;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDb();


var app = builder.Build();

app.MapGamesEndPoints();

app.MigrateDb();

app.Run();







