using MovieAPI.Models;

namespace MovieAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetFilteredMoviesAsync(MovieFilter filter);
    }
}

