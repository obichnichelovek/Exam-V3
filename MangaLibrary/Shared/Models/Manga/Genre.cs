using MangaLibrary.Shared.Models.Manga.JoinTables;
using MangaLibrary.Shared.Enums;
//using MangaLibrary.Shared.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MangaLibrary.Shared.Services;

namespace MangaLibrary.Shared.Models.Manga;

//[JsonConverter(typeof(TagsJsonConverter))]
public sealed class Genre : TagBase
{
    [JsonIgnore]
    public ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();

    public Genre(Genres genre)
    {
        ID = (int)genre;
        Name = Tools.GetCustomName(genre) ?? Tools.FixCase(Tools.GetEnumName(genre));
        Description = Tools.GetEnumDescription(genre);
    }
    public Genre() { }
}
