namespace MangaLibrary.Shared.Models.Manga.JoinTables;

public sealed class MangaGenre
{
    public int MangaID { get; set; }
    public Manga Manga { get; set; } = null!;

    public int GenreID { get; set; }
    public Genre Genre { get; set; } = null!;
}
