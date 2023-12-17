using MangaLibrary.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class Bookmark
{
    [Required(ErrorMessage = "ID missing.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int ID { get; set; }

    [Required(ErrorMessage = "Manga missing.")]
    public Manga Manga { get; set; } = null!;

    [Required(ErrorMessage = "Bookmark type missing.")]
    public BookmarkType BookmarkType { get; set; }
}
