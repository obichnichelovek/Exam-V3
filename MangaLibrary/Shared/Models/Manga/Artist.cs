using System.Text.Json.Serialization;
using MangaLibrary.Shared.Models.Manga.JoinTables;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class Artist : AccreditedEntity
{
    [JsonIgnore]
    public ICollection<MangaArtist> MangaArtists { get; set; } = new List<MangaArtist>();

    public Artist(string name) : base(name) { }
    public Artist() : base() { }
}
