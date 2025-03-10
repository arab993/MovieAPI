using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieDbContext _context;

    public MovieRepository(MovieDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetFilteredMoviesAsync(MovieFilter filter)
    {
        try
        {
            var query = _context.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(m => m.Title.Contains(filter.Title));

            if (!string.IsNullOrEmpty(filter.Genre))
                query = query.Where(m => m.Genre == filter.Genre);

            if (!string.IsNullOrEmpty(filter.Actor))
            {
                // NOTE: Since database does not have a dedicated "Actor" or "Cast" column,
                // assuming that the actor names might be present in the "Overview" column.
                query = query.Where(m => m.Overview.Contains(filter.Actor));
            }

            query = filter.SortBy switch
            {
                "title" => query.OrderBy(m => m.Title),
                "release_date" => query.OrderBy(m => m.Release_Date),
                _ => query
            };

            return await query.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving movies", ex);
        }
    }
}
