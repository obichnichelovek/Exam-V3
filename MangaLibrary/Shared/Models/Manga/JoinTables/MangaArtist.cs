using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public sealed class MangaArtist : MangaManga
{
    public int ArtistID { get; set; }
    [JsonIgnore]
    public Artist Artist { get; set; } = null!;
}
