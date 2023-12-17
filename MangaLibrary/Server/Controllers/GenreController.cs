﻿using MangaLibrary.Shared.Models.Manga;
using MangaLibrary.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MangaLibrary.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class GenreController : ControllerBase
{
    private readonly MangaRepository _repo;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
    {
        var (genres, metadata) = await _repo.GetGenres();
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

        return Ok(genres);
    }

    public GenreController(MangaRepository repository) => _repo = repository;
}
