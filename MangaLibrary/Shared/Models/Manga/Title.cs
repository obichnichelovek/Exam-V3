using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class Title
{
    [Required(ErrorMessage = "MangaID missing.")]
    [ForeignKey("MangaID")]
    [JsonIgnore]
    public int MangaID { get; set; }

    [Required(ErrorMessage = "English title missing.")]
    [MaxLength(256, ErrorMessage = "English title length exceeded the allowed amount of characters (256).")]
    public string English { get; set; } = null!;

    [Required(ErrorMessage = "Japanese title missing.")]
    [MaxLength(256, ErrorMessage = "Japanese title length exceeded the allowed amount of characters (256).")]
    public string Japanese { get; set; } = null!;

    [Required(ErrorMessage = "Romaji title missing.")]
    [MaxLength(256, ErrorMessage = "Romaji title length exceeded the allowed amount of characters (256).")]
    public string Romaji { get; set; } = null!;
}
