using ApiFilmes.Services;
using AspNetCoreRefitDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiFilmes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmesController : ControllerBase
{
    private readonly ITmdb _tmdb;
    public FilmesController(ITmdb tmdb)
    {
        _tmdb = tmdb;
    }

    [HttpGet("actors/")]
    public async Task<ActorList> GetActors([FromQuery][Required] string name)
    {
        var response = await _tmdb.GetActors(name);
        return response;
    }

    [HttpGet("actors/{actorId}/movies")]
    public async Task<MovieList> GetMovies(int actorId)
    {
        var response = await _tmdb.GetMovies(actorId);
        return response;
    }

    [HttpGet("movies/{movieId}")]
    public async Task<MovieDetails> GetMovieDetails(int movieId)
    {
        var response = await _tmdb.GetMovieDetails(movieId);
        return response;
    }

    [HttpPost("movies/{movieId}/rating")]
    public async Task<ResponseBody> AddRating(int movieId, [FromBody] Rating rating)
    {
        var response = await _tmdb.AddRating(movieId, rating);
        return response;
    }

    [HttpDelete("movies/{movieId}/rating")]
    public async Task<ResponseBody> DeleteRating(int movieId)
    {
        var response = await _tmdb.DeleteRating(movieId);
        return response;
    }
}
