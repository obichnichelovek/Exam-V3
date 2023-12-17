using System.Text.Json.Serialization;
using MangaLibrary.Shared.Models.Manga.JoinTables;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class Publishing : AccreditedEntity
{
    public string? URL { get; set; }

    [JsonIgnore]
    public ICollection<MangaPublishing> MangaPublishings { get; set; } = new List<MangaPublishing>();

    public Publishing(string name) : base(name) { }
    public Publishing() { }
}
