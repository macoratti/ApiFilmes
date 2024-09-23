using ApiFilmes.Services;
using AspNetCoreRefitDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class FilmesApiController : ControllerBase
{
    private readonly ITmdb _tmdb;

    public FilmesApiController(ITmdb tmdb)
    {
        _tmdb = tmdb;
    }

    [HttpGet("actors/")]
    public async Task<IActionResult> GetActors([FromQuery][Required] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return BadRequest("O nome do ator é obrigatório.");
        }

        try
        {
            var response = await _tmdb.GetActors(name);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar atores: {ex.Message}");
        }
    }

    [HttpGet("actors/{actorId}/movies")]
    public async Task<IActionResult> GetMovies(int actorId)
    {
        try
        {
            var response = await _tmdb.GetMovies(actorId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar filmes do ator: {ex.Message}");
        }
    }

    [HttpGet("movies/{movieId}")]
    public async Task<IActionResult> GetMovieDetails(int movieId)
    {
        try
        {
            var response = await _tmdb.GetMovieDetails(movieId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar detalhes do filme: {ex.Message}");
        }
    }

    [HttpPost("movies/{movieId}/rating")]
    public async Task<IActionResult> AddRating(int movieId, [FromBody] Rating rating)
    {
        if (rating == null)
        {
            return BadRequest("A classificação não pode ser nula.");
        }

        try
        {
            var response = await _tmdb.AddRating(movieId, rating);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar classificação: {ex.Message}");
        }
    }

    [HttpDelete("movies/{movieId}/rating")]
    public async Task<IActionResult> DeleteRating(int movieId)
    {
        try
        {
            var response = await _tmdb.DeleteRating(movieId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao remover classificação: {ex.Message}");
        }
    }
}
