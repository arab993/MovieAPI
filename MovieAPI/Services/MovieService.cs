using MovieAPI.DTOs;
using MovieAPI.Models;
using MovieAPI.Repositories;
using MovieAPI.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<IEnumerable<MovieDTO>> SearchMoviesAsync(MovieFilter filter)
    {
        try
        {
            var movies = await _movieRepository.GetFilteredMoviesAsync(filter);
            return movies.Select(m => new MovieDTO
            {
                Title = m.Title,
                Overview = m.Overview,
                Popularity = m.Popularity,
                Vote_Average = m.Vote_Average,
                Genre = m.Genre,
                Poster_Url = m.Poster_Url,
                Release_Date = m.Release_Date
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new Exception("Error processing movie search", ex);
        }
    }
}
