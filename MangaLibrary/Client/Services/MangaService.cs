using MangaLibrary.Shared.Enums;
using MangaLibrary.Shared.Models.Manga;
using System.Net.Http;
using System.Net.Http.Json;

namespace MangaLibrary.Client.Services;

public sealed class MangaService
{
    private readonly HttpClient _http;
    private const string API = "api/Manga";

    public event Action? MangaChange;

    public List<Manga>? Mangas { get; set; } = new();
    public List<Tag>? Tags { get;set; } = new();
    public List<Genre>? Genres { get; set; } = new();

    public async Task AddManga(Manga manga)
    {
        await _http.PostAsJsonAsync(API, manga);
    }

    public async Task GetMangas()
    {
        Mangas = await _http.GetFromJsonAsync<List<Manga>?>($"{API}");
        MangaChange?.Invoke();
    }

    public async Task AdvancedSearch(AdvancedSearchRequest r)
    {
        Mangas = await _http.GetFromJsonAsync<List<Manga>?>($"{API}/advanced-search?t={r.Title}&a={r.Author}&ar={r.Artist}&p={r.Publishing}&nOptions={r.TitleSearchOption}{r.AuthorSearchOption}{r.ArtistSearchOption}{r.PublishingSearchOption}&y={r.Year}&yType={r.YearSearchOption}&gI={r.Genres}&gE={r.GenreBlacklist}&tI={r.Tags}&tE={r.TagBlacklist}&tOption={r.TagSearchOption}&sOption={r.SearchOption}&page={1}&pageSize={5}");
        MangaChange?.Invoke();
    }

    public async Task Search(string query)
    {
        Mangas = await _http.GetFromJsonAsync<List<Manga>?>($"{API}/search/{query}");
        MangaChange?.Invoke();
    }

    public async Task<List<Manga>?> GetMangaByTag(int id) => await _http.GetFromJsonAsync<List<Manga>?>($"{API}/tag/{id}");

    public async Task<List<Manga>?> GetMangaByGenre(int id) => await _http.GetFromJsonAsync<List<Manga>?>($"{API}/genre/{id}");

    public async Task<List<string>?> SearchSuggestions(string query) => await _http.GetFromJsonAsync<List<string>?>($"{API}/search-suggestions/{query}");

    public async Task GetMangasByPublishingID(int id) => await _http.GetFromJsonAsync<List<Manga>>($"{API}/publishing/{id}");

    public async Task GetMangasByArtistID(int id) => await _http.GetFromJsonAsync<List<Manga>>($"{API}/artist/{id}");

    public async Task<Manga?> GetMangaByID(int id) => await _http.GetFromJsonAsync<Manga?>($"{API}/{id}");

    public async Task GetMangasByAuthorID(int id) => Mangas = await _http.GetFromJsonAsync<List<Manga>?>($"{API}/author/{id}");

    public async Task GetGenres() => Genres = await _http.GetFromJsonAsync<List<Genre>>($"api/Genre");

    public async Task GetTags() => Tags = await _http.GetFromJsonAsync<List<Tag>>($"api/Tag");

    public MangaService(HttpClient httpClient) => _http = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
}
