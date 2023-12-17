using MangaLibrary.Shared.Enums;

namespace MangaLibrary.Shared.Models.Manga;

public sealed class AdvancedSearchRequest
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public string? Publishing { get; set; }

    public NameSearchOptions TitleSearchOption { get; set; }
    public NameSearchOptions AuthorSearchOption { get; set; }
    public NameSearchOptions ArtistSearchOption { get; set; }
    public NameSearchOptions PublishingSearchOption { get; set; }

    public SearchOptions SearchOption { get; set; }

    public TagSearchOptions TagSearchOption { get; set; }

    public short Year { get; set; }
    public ReleaseYearSearchOptions YearSearchOption { get; set; }

    public List<int> Genres { get; set; } = new();
    public List<int> Tags { get; set; } = new();

    public List<int> GenreBlacklist { get; set; } = new();
    public List<int> TagBlacklist { get; set; } = new();
}
