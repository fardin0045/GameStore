using System;
using System.Runtime.InteropServices;

namespace GameStore.api.Models;

public class Game
{
    public int Id{get; set;}
    public required string Name {get; set;}
    public Genre? PGenre{get; set;}
    public int GenreId {get; set;}
    public DateOnly ReleaseDate {get; set;}

}
