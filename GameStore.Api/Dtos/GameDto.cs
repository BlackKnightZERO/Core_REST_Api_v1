namespace GameStore.Api.Dtos;

// public record class GameDto(
//     int Id,
//     string Name,
//     string Genre,
//     decimal Price,
//     DateOnly ReleaseDate
// );

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class GameDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }

    [JsonConverter(typeof(DateOnlyConverter))]
    public DateOnly ReleaseDate { get; set; }

    // Constructor
    public GameDto(int id, string name, string genre, decimal price, DateOnly releaseDate)
    {
        Id = id;
        Name = name;
        Genre = genre;
        Price = price;
        ReleaseDate = releaseDate;
    }

    // Default constructor for serialization
    public GameDto() { }
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && DateOnly.TryParse(reader.GetString(), out DateOnly date))
        {
            return date;
        }
        throw new JsonException("Invalid date format.");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}

