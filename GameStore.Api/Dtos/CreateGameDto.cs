﻿namespace GameStore.Api.Dtos;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public record class CreateGameDto
{
    public string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly ReleaseDate { get; set; }

    public CreateGameDto(int id, string name, string genre, decimal price, DateOnly releaseDate)
    {
        Name = name;
        Genre = genre;
        Price = price;
        ReleaseDate = releaseDate;
    }

    // Default constructor for serialization
    public CreateGameDto() { }
}
