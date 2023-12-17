using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public sealed class MangaPublishing : MangaManga
{
    public int PublishingID { get; set; }
    [JsonIgnore]
    public Publishing Publishing { get; set; } = null!;
}
