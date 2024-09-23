using AspNetCoreRefitDemo.Models;
using Refit;

namespace ApiFilmes.Services;

[Headers("accept: application/json","Authorization: Bearer")]
public interface ITmdb
{
    [Get("/search/person?query={name}")]
    Task<ActorList> GetActors(string name);

    [Get("/person/{actorId}/movie_credits?language=en-US")]
    Task<MovieList> GetMovies(int actorId);
    
    [Get("/movie/{movieId}?language=en-US")]
    Task<MovieDetails> GetMovieDetails(int movieId);

    [Headers("Content-Type: application/json;charset=utf-8")]
    [Post("/movie/{movieId}/rating")]
    Task<ResponseBody> AddRating(int movieId, [Body] Rating rating);
    
    [Delete("/movie/{movieId}/rating")]
    Task<ResponseBody> DeleteRating(int movieId);
}
