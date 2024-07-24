namespace GameStore.Api.Dtos;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class UpdateGameDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly ReleaseDate { get; set; }

    // Constructor
    public UpdateGameDto(int id, string name, string genre, decimal price, DateOnly releaseDate)
    {
        Id = id;
        Name = name;
        Genre = genre;
        Price = price;
        ReleaseDate = releaseDate;
    }

    // Default constructor for serialization
    public UpdateGameDto() { }
}

