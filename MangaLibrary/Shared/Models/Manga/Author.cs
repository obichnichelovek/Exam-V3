using System.Text.Json.Serialization;
using MangaLibrary.Shared.Models.Manga.JoinTables;

namespace MangaLibrary.Shared.Models.Manga;

public class Author : AccreditedEntity
{
    [JsonIgnore]
    public ICollection<MangaAuthor> MangaAuthors { get; set; } = new List<MangaAuthor>();

    public Author(string name) : base(name) { }
    public Author() : base() { }
}
