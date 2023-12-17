using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public class MangaManga
{
    public int MangaID { get; set; }
    [JsonIgnore]
    public Manga Manga { get; set; } = null!;
}
