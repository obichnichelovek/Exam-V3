using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class MangaDetails
{
    [Required(ErrorMessage = "MangaID missing.")]
    [ForeignKey("MangaID")]
    public int MangaID { get; set; }

    public DateTime UpdateDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Description missing.")]
    [MaxLength(1024, ErrorMessage = "Description length exceeded the allowed amount of characters (1024).")]
    public string Description { get; set; } = null!;


    [Required(ErrorMessage = "Release year missing.")]
    [Range(1900, 3000, ErrorMessage = "Release year was too old or too young (min: 1900 max: 3000)")]
    public short ReleaseYear { get; set; }

    public short Volumes { get; set; }
    public short Chapters { get; set; }

    public int Bookmarks { get; set; }
    public int Favorites { get; set; }

    public DateTime PublishDate { get; set; }
}
