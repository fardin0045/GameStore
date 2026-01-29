using System.ComponentModel.DataAnnotations;

namespace GameStore.api.Dtos;

public record UpdateGameDto(
   [Required]
    [StringLength(40)]
    string Name,
    [Required]
    [StringLength(40)]
    string Genre,
    [Required]
    [Range(1,100)]
    decimal Price,
    DateOnly ReleaseDate
);
