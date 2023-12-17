using MangaLibrary.Shared.Models.Manga.JoinTables;
using MangaLibrary.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga;

public class Manga
{
    [Required(ErrorMessage = "ID missing.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required(ErrorMessage = "Title missing.")]
    public Title Title { get; set; } = null!;

    [Required(ErrorMessage = "Poster missing.")]
    [MaxLength(256, ErrorMessage = "Poster length exceeded the allowed amount of characters (256).")]
    public string Poster { get; set; } = null!;

    [Required(ErrorMessage = "Rating missing.")]
    [Range(0.0f, 5.0f, ErrorMessage = "Rating is lower or greater than allowed (min: 0 max: 5)")]
    public float Rating { get; set; }

    [Required(ErrorMessage = "Tags missing.")]
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    [Required(ErrorMessage = "Genres missing.")]
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public MangaDetails Details { get; set; } = null!;


    #region COLLECTIONS
    [MinLength(1, ErrorMessage = "Authors missing.")]
    public ICollection<Author> Authors { get; set; } = new List<Author>();

    public ICollection<Artist> Artists { get; set; } = new List<Artist>();

    [MinLength(1, ErrorMessage = "Authors missing.")]
    public ICollection<Publishing> Publishings { get; set; } = new List<Publishing>();

    [JsonIgnore]
    public ICollection<MangaAuthor> MangaAuthors { get; set; } = new List<MangaAuthor>();

    [JsonIgnore]
    public ICollection<MangaArtist> MangaArtists { get; set; } = new List<MangaArtist>();

    [JsonIgnore]
    public ICollection<MangaPublishing> MangaPublishings { get; set; } = new List<MangaPublishing>();

    [JsonIgnore]
    public ICollection<MangaTag> MangaTags { get; set; } = new List<MangaTag>();

    [JsonIgnore]
    public ICollection<MangaGenre> MangaGenres { get; set; } = new List<MangaGenre>();
    #endregion
}
