using System.ComponentModel.DataAnnotations;

namespace MangaLibrary.Shared.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class DescriptionAttribute : Attribute
{
    [MaxLength(24, ErrorMessage = "Tag/Genre name's length exceeded the allowed amount of characters (24).")]
    public string? Name { get; set; }
    [Required]
    [MaxLength(256, ErrorMessage = "Tag/Genre description's length exceeded the allowed amount of characters (256).")]
    public string Description { get; set; }

    public DescriptionAttribute(string description) => Description = description;
}
