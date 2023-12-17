//using MangaLibrary.Shared.Services;
using System.Text.Json.Serialization;

namespace MangaLibrary.Shared.Enums;

//[JsonConverter(typeof(TagSearchOptionsJsonConverter))]
public enum TagSearchOptions : byte
{
    And = 1,
    Or
}
