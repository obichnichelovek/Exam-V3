using MangaLibrary.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga;

public class TagBase
{
    [Required(ErrorMessage = "ID missing.")]
    [Key]
    public int ID { get; set; }

    [Required(ErrorMessage = "Name missing.")]
    [MaxLength(32, ErrorMessage = "Name length exceeded the allowed amount of characters (32).")]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Manga> Mangas { get; set; } = new List<Manga>();
}
