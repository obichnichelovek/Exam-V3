using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public sealed class MangaAuthor : MangaManga
{
    public int AuthorID { get; set; }
    [JsonIgnore]
    public Author Author { get; set; } = null!;
}
