using MangaLibrary.Shared.Enums;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public sealed class MangaTag
{
    public int MangaID { get; set; }
    [JsonIgnore]
    public Manga Manga { get; set; } = null!;

    public int TagID { get; set; }
    public Tag Tag { get; set; } = null!;
}
