using GameStore.api.Dtos;
using GameStore.api.EndPoints;
using GameStore.Api.Dtos;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndPoints();

app.Run();







