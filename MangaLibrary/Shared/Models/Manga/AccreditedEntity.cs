using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Models.Manga;

public class AccreditedEntity
{
    [Required(ErrorMessage = "ID mising.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public int ID { get; set; }
    [Required(ErrorMessage = "Name missing.")]
    [MaxLength(32, ErrorMessage = "Name length exceeded the allowed amount of characters (32).")]
    public string Name { get; set; } = null!;
    [MaxLength(256, ErrorMessage = "Description length exceeded the allowed amount of characters (256).")]
    public string? Description { get; set; }

    [JsonIgnore]
    public ICollection<Manga> Mangas { get; set; } = new List<Manga>();

    public AccreditedEntity(string name) => Name = name;
    public AccreditedEntity() { }
}
