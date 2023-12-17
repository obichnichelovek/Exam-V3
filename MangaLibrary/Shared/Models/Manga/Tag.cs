using MangaLibrary.Shared.Models.Manga.JoinTables;
using MangaLibrary.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MangaLibrary.Shared.Services;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class Tag : TagBase
{
    [JsonIgnore]
    public ICollection<MangaTag> MangaTags { get; set; } = new List<MangaTag>();

    public Tag(Tags tag)
    {
        ID = (int)tag;
        Name = Tools.FixCase(Tools.GetEnumName(tag));
        Description = Tools.GetEnumDescription(tag);
    }
    public Tag() { }
}