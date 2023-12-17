using MangaLibrary.Shared.Enums;
using MangaLibrary.Shared.Models.Manga;
using MangaLibrary.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MangaLibrary.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MangaController : ControllerBase
{
    private readonly MangaRepository _repo;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangas(int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangas(pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpPost("{manga}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> AddManga(Manga manga)
    {
        await _repo.AddManga(manga);
        return Ok();
    }

    //t: title a: Author ar: Artist p: Publishing y: ReleaseYear yType: ReleaseYearSearchOptions gI: included genres gE: excluded genres sOptions: search options

    [HttpGet("advanced-search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> AdvancedSearch(string? t, string? a, string? ar, string? p, string nOptions, string? y, ReleaseYearSearchOptions yType, string? gI, string? gE, string? tI, string? tE, TagSearchOptions tOption, SearchOptions sOption, int page = 1, int pageSize = 5)
    {
        var (mangas, metadata) = await _repo.SearchAdvanced(pageSize, page, t, a, ar, p, nOptions, y, yType, gI, gE, tI, tE, tOption, sOption);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpGet("search/{query}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> Search(string query, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.Search(query, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpGet("search-suggestions/{query}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<string>>> SearchSuggestions(string query)
    {
        var (titles, metadata) = await _repo.SearchSuggestions(query);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(titles);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Manga?>> GetMangaByID(int id)
    {
        var manga = await _repo.GetMangaByID(id);
        if (manga is null) return NotFound();
        return Ok(manga);
    }

    [HttpGet("genre/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangasByGenre(int id, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangasByGenre(id, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpGet("tag/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangasByTags(int id, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangasByTags(id, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpGet("publishing/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangasByPublishingID(int id, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangasByPublishingID(id, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }


    [HttpGet("artist/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangasByArtistID(int id, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangasByArtistID(id, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    [HttpGet("author/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Manga>>> GetMangasByAuthorID(int id, int pageSize = 10, int page = 1)
    {
        var (mangas, metadata) = await _repo.GetMangasByAuthorID(id, pageSize, page);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(mangas);
    }

    //[HttpGet("query")]
    //public async Task<ActionResult<ICollection<Manga>>> Search(string query, int pageSize = 2, int page = 1)
    //{
    //    var (mangas, metadata) = await _repo.Search(query, pageSize, page);
    //    Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

    //    return Ok(mangas);
    //}

    public MangaController(MangaRepository repository) => _repo = repository;
}
