using MovieAPI.DTOs;
using MovieAPI.Models;

namespace MovieAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> SearchMoviesAsync(MovieFilter filter);
    }
}

