using MangaLibrary.Shared.Contexts;
using MangaLibrary.Shared.Enums;
using MangaLibrary.Shared.Models.Manga;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MangaLibrary.Shared.Services;

public sealed class MangaRepository
{
    private readonly MangaContext _context;

    public async Task<(IEnumerable<string>, PaginationMetadata)> SearchSuggestions(string query)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, 5, 1);

        var titles = await SearchByTitle(collection, query)
            .OrderByDescending(x => x.Rating)
            .Take(5)
            .Select(x => x.Title.English)
            .ToListAsync();

        return (titles, metadata);

    }

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> Search(string query, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        collection = SearchByTitle(collection, query.Trim());

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.OrderBy(x => x.Title.English).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
        return (returnCollection, metadata);
    }

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> SearchAdvanced(int page, int pageSize, string? t, string? a, string? ar, string? p, string nOptions, string? y, ReleaseYearSearchOptions yType, string? gI, string? gE, string? tI, string? tE, TagSearchOptions tOption, SearchOptions sOption)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var included = new List<int>();
        var excluded = new List<int>();

        var nameOptions = nOptions.Select(x => (NameSearchOptions)(x - '0')).ToArray();

        if (!string.IsNullOrEmpty(t))
            collection = SearchByTitle(collection, t, nameOptions[0]);

        collection = SearchByAccreditedEntities(collection, nameOptions, a, ar, p);

        if (!string.IsNullOrEmpty(gI))
        {
            collection = collection.Include(x => x.Genres);
            foreach (var g in gI) included.Add(g - '0');
        }

        if (!string.IsNullOrEmpty(gE))
        {
            collection = collection.Include(x => x.Genres);
            foreach (var g in gE) excluded.Add(g - '0');
        }

        switch (tOption)
        {
            case TagSearchOptions.And:
                foreach (var id in included)
                    collection = collection.Where(x => x.Genres.Any(y => y.ID == id));
                foreach (var id in excluded)
                    collection = collection.Where(x => !x.Genres.Any(y => y.ID == id));
                break;
            case TagSearchOptions.Or:
                foreach (var id in included)
                    if (collection.Any(x => x.Genres.Any(y => y.ID == id)))
                    {
                        collection = collection.Where(x => x.Genres.Any(y => y.ID == id));
                        break;
                    }
                foreach (var id in excluded)
                    if (collection.Any(x => !x.Genres.Any(y => y.ID == id)))
                    {
                        collection = collection.Where(x => !x.Genres.Any(y => y.ID == id));
                        break;
                    }
                break;
        }

        included.Clear();
        excluded.Clear();

        if (!string.IsNullOrEmpty(tI))
        {
            collection = collection.Include(x => x.Tags);
            foreach (var tag in tI) included.Add(tag - '0');
        }

        if (!string.IsNullOrEmpty(tE))
        {
            collection = collection.Include(x => x.Tags);
            foreach (var tag in tE) excluded.Add(tag - '0');
        }

        switch (tOption)
        {
            case TagSearchOptions.And:
                foreach (var id in included)
                    collection = collection.Where(x => x.Tags.Any(y => y.ID == id));
                foreach (var id in excluded)
                    collection = collection.Where(x => !x.Tags.Any(y => y.ID == id));
                break;
            case TagSearchOptions.Or:
                foreach (var id in included)
                    if (collection.Any(x => x.Tags.Any(y => y.ID == id)))
                    {
                        collection = collection.Where(x => x.Tags.Any(y => y.ID == id));
                        break;
                    }
                foreach (var id in excluded)
                    if (collection.Any(x => !x.Tags.Any(y => y.ID == id)))
                    {
                        collection = collection.Where(x => !x.Tags.Any(y => y.ID == id));
                        break;
                    }
                break;
        }

        if (!string.IsNullOrEmpty(y))
        {
            var year = short.Parse(y);
            switch (yType)
            {
                case ReleaseYearSearchOptions.In:
                    collection = collection.Where(x => x.Details.ReleaseYear == year);
                    break;

                case ReleaseYearSearchOptions.Before:
                    collection = collection.Where(x => x.Details.ReleaseYear < year);
                    break;

                case ReleaseYearSearchOptions.After:
                    collection = collection.Where(x => x.Details.ReleaseYear > year);
                    break;
            }
        }

        switch (sOption)
        {
            case SearchOptions.Alphabet:
                collection = collection.OrderBy(x => x.Title.English);
                break;
            case SearchOptions.AlphabetDescending:
                collection = collection.OrderByDescending(x => x.Title.English);
                break;

            case SearchOptions.Rating:
                collection = collection.OrderBy(x => x.Rating);
                break;
            case SearchOptions.RatingDescending:
                collection = collection.OrderByDescending(x => x.Rating);
                break;

            case SearchOptions.Year:
                collection = collection.OrderBy(x => x.Details.ReleaseYear);
                break;
            case SearchOptions.YearDescending:
                collection = collection.OrderByDescending(x => x.Details.ReleaseYear);
                break;

            case SearchOptions.Add:
                collection = collection.Include(x => x.Details).OrderBy(x => x.Details.PublishDate);
                break;
            case SearchOptions.AddDescending:
                collection = collection.Include(x => x.Details).OrderByDescending(x => x.Details.PublishDate);
                break;
        }

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.ToListAsync();

        return (returnCollection, metadata);
    }

    public async Task AddManga(Manga manga)
    {
        _context.Mangas.Add(manga);
        await _context.SaveChangesAsync();
    }

    public async Task<(ICollection<Manga>, PaginationMetadata)> GetMangasByTags(int id, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.Include(x => x.Tags).Where(x => x.Tags.Any(y => y.ID == id)).ToListAsync();
        return (returnCollection, metadata);
    }

    public async Task<(ICollection<Manga>, PaginationMetadata)> GetMangasByGenre(int id, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.Include(x => x.Genres).Where(x => x.Genres.Any(y => y.ID == id)).ToListAsync();
        return (returnCollection, metadata);
    }

    //public async Task<(IEnumerable<Manga>, PaginationMetadata)> SearchAdvanced(string? title, string? author, string? artist, string? publishing, Tag[]? tags, Genre[]? genres, TagSearchOptions tagSearch, int pageSize, int page)
    //{
    //    var collection = _context.Mangas as IQueryable<Manga>;

    //    if (!string.IsNullOrEmpty(title))
    //        collection = SearchByTitle(collection, title);

    //    collection = SearchByAccreditedEntities(collection, author, artist, publishing);

    //    if (tags is not null)
    //        collection = SearchTags(collection, tagSearch, tags);

    //    if (genres is not null)
    //        collection = SearchByGenres(collection, tagSearch, genres);

    //    var count = await collection.CountAsync();
    //    var metadata = new PaginationMetadata(count, pageSize, page);

    //    var returnCollection = await collection.OrderByDescending(x => x.Rating).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
    //    return (returnCollection, metadata);
    //}

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> GetMangas(int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.OrderByDescending(x => x.Rating).Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
        return (returnCollection, metadata);
    }

    public async Task<Manga?> GetMangaByID(int id) =>
        await _context.Mangas
            .Include(x => x.Authors)
            .Include(x => x.Artists)
            .Include(x => x.Publishings)
            .Include(x => x.Genres)
            .Include(x => x.Tags)
            .Where(x => x.ID == id)
            .AsSplitQuery()
            .FirstAsync();

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> GetMangasByPublishingID(int id, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.Include(x => x.Publishings)
            .OrderByDescending(x => x.Rating)
            .Where(x => x.Publishings.Any(y => y.ID == id))
            .Skip(pageSize * (page - 1))
            .Take(pageSize).ToListAsync();

        return (returnCollection, metadata);
    }

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> GetMangasByArtistID(int id, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.Include(x => x.Artists)
            .OrderByDescending(x => x.Rating)
            .Where(x => x.Artists.Any(y => y.ID == id))
            .Skip(pageSize * (page - 1))
            .Take(pageSize).ToListAsync();

        return (returnCollection, metadata);
    }

    public async Task<(IEnumerable<Manga>, PaginationMetadata)> GetMangasByAuthorID(int id, int pageSize, int page)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, pageSize, page);

        var returnCollection = await collection.Include(x => x.Authors)
            .OrderByDescending(x => x.Rating)
            .Where(x => x.Authors.Any(y => y.ID == id))
            .Skip(pageSize * (page - 1))
            .Take(pageSize).ToListAsync();

        return (returnCollection, metadata);
    }

    public Manga? GetMangaByName(string title)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        if (IsJapanese(title)) return collection.Where(x => x.Title.Japanese == title).First();
        return collection.Where(x => x.Title.English == title | x.Title.Romaji == title).First();
    }

    public IEnumerable<Manga> GetMangasByNames(params string[] titles)
    {
        var collection = _context.Mangas as IQueryable<Manga>;

        for (byte i = 0; i < titles.Length; i++)
        {
            if (IsJapanese(titles[i])) collection = collection.Where(x => x.Title.Japanese == titles[i]);
            collection = collection.Where(x => x.Title.English == titles[i] | x.Title.Romaji == titles[i]);
        }
        return collection.ToList();
    }

    public void DeleteMangas(params string[] titles)
    {
        var collection = _context.Mangas as IQueryable<Manga>;
        for (byte i = 0; i < titles.Length; i++)
        {
            var manga = collection.Where(x => x.Title.English == titles[i]).First();
            _context.Mangas.Remove(manga);
        }
    }

    public void DeleteManga(string title)
    {
        var collection = _context.Mangas as IQueryable<Manga>;
        var manga = collection.Where(x => x.Title.English == title).First();

        _context.Mangas.Remove(manga);
    }

    public async Task<(IEnumerable<Tag>, PaginationMetadata)> GetTags()
    {
        var collection = _context.Tags as IQueryable<Tag>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, count, 1);

        var returnCollection = await collection.OrderBy(x => x.Name).ToListAsync();

        return (returnCollection, metadata);
    }

    public async Task<(IEnumerable<Genre>, PaginationMetadata)> GetGenres()
    {
        var collection = _context.Genres as IQueryable<Genre>;

        var count = await collection.CountAsync();
        var metadata = new PaginationMetadata(count, count, 1);

        var returnCollection = await collection.OrderBy(x => x.Name).ToListAsync();

        return (returnCollection, metadata);
    }

    /*   !    -    !    -    !    -    !    -    !   -   PRIVATE STATIC METHODS  -   !    -    !    -    !    -    !    -   !   -   */

    private static IQueryable<Manga> SearchByTitle(IQueryable<Manga> collection, string title, NameSearchOptions options)
    {
        title = title.Trim();
        switch (options)
        {
            case NameSearchOptions.StartsWith:
                if (IsJapanese(title)) return collection.Where(x => x.Title.Japanese.StartsWith(title));

                return collection.Where(x => x.Title.English.StartsWith(title) | x.Title.Romaji.StartsWith(title));

            default:
            case NameSearchOptions.Contains:
                if (IsJapanese(title)) return collection.Where(x => x.Title.Japanese.Contains(title));

                return collection.Where(x => x.Title.English.Contains(title) | x.Title.Romaji.Contains(title));

            case NameSearchOptions.EndsWith:
                if (IsJapanese(title)) return collection.Where(x => x.Title.Japanese.EndsWith(title));

                return collection.Where(x => x.Title.English.EndsWith(title) | x.Title.Romaji.EndsWith(title));
        }
    }

    private static IQueryable<Manga> SearchByTitle(IQueryable<Manga> collection, string title)
    {
        title = title.Trim();
        if (IsJapanese(title)) return collection.Where(x => x.Title.Japanese.Contains(title));

        return collection.Where(x => x.Title.English.Contains(title) | x.Title.Romaji.Contains(title));
    }

    private static IQueryable<Manga> SearchByGenres(IQueryable<Manga> collection, TagSearchOptions tagOptions, Genre[] genres)
    {
        switch (tagOptions)
        {
            case TagSearchOptions.And:
                for (byte i = 0; i < genres.Length; i++)
                    collection = collection.Include(x => x.Genres).Where(x => x.Genres.Contains(genres[i]));
                break;

            case TagSearchOptions.Or:
                for (byte i = 0; i < genres.Length; i++)
                    if (collection.Any(x => x.Genres.Contains(genres[i])))
                    {
                        collection = collection.Include(x => x.Genres).Where(x => x.Genres.Contains(genres[i]));
                        break;
                    }
                break;
        }

        return collection;
    }

    private static IQueryable<Manga> SearchTags(IQueryable<Manga> collection, TagSearchOptions tagOptions, Tag[] tags)
    {
        switch (tagOptions)
        {
            case TagSearchOptions.And:
                for (byte i = 0; i < tags.Length; i++)
                    collection = collection.Include(x => x.Tags).Where(x => x.Tags.Contains(tags[i]));
                break;

            case TagSearchOptions.Or:
                for (byte i = 0; i < tags.Length; i++)
                    if (collection.Any(x => x.Tags.Contains(tags[i])))
                    {
                        collection = collection.Include(x => x.Tags).Where(x => x.Tags.Contains(tags[i]));
                        break;
                    }
                break;
        }

        return collection;
    }

    private static IQueryable<Manga> SearchByAccreditedEntities(IQueryable<Manga> collection, NameSearchOptions[] options, params string?[] entities)
    {
        for (byte i = 0; i < entities.Length; i++)
            if (entities[i] is not null)
            {
                var entity = entities[i]!.Trim();
                switch (i)
                {
                    case 0:
                        switch (options[1])
                        {
                            case NameSearchOptions.StartsWith:
                                collection = collection.Include(x => x.Authors).Where(x => x.Authors.Any(y => y.Name.StartsWith(entity)));
                                break;

                            case NameSearchOptions.Contains:
                                collection = collection.Include(x => x.Authors).Where(x => x.Authors.Any(y => y.Name.Contains(entity)));
                                break;

                            case NameSearchOptions.EndsWith:
                                collection = collection.Include(x => x.Authors).Where(x => x.Authors.Any(y => y.Name.EndsWith(entity)));
                                break;
                        }
                        break;
                    case 1:
                        switch (options[2])
                        {
                            case NameSearchOptions.StartsWith:
                                collection = collection.Include(x => x.Artists).Where(x => x.Artists.Any(y => y.Name.StartsWith(entity)));
                                break;

                            case NameSearchOptions.Contains:
                                collection = collection.Include(x => x.Artists).Where(x => x.Artists.Any(y => y.Name.Contains(entity)));
                                break;

                            case NameSearchOptions.EndsWith:
                                collection = collection.Include(x => x.Artists).Where(x => x.Artists.Any(y => y.Name.EndsWith(entity)));
                                break;
                        }
                        break;
                    case 2:
                        switch (options[3])
                        {
                            case NameSearchOptions.StartsWith:
                                collection = collection.Include(x => x.Publishings).Where(x => x.Publishings.Any(y => y.Name.StartsWith(entity)));
                                break;

                            case NameSearchOptions.Contains:
                                collection = collection.Include(x => x.Publishings).Where(x => x.Publishings.Any(y => y.Name.Contains(entity)));
                                break;

                            case NameSearchOptions.EndsWith:
                                collection = collection.Include(x => x.Publishings).Where(x => x.Publishings.Any(y => y.Name.EndsWith(entity)));
                                break;
                        }
                        break;
                    default: return collection;
                }
            }
        return collection;
    }

    private static bool IsJapanese(string text)
    {
        switch (text[0] >= 0x3000 && text[0] <= 0x303f)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x3040 && text[0] <= 0x309f)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x30a0 && text[0] <= 0x30ff)
        {
            case true: return true;
            default:
            case false: break;
        }

        switch (text[0] >= 0x4e00 && text[0] <= 0x9faf)
        {
            case true: return true;
            default:
            case false: break;
        }

        return false;
    }

    public MangaRepository(MangaContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));
}
