using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] MovieFilter filter)
    {
        try
        {
            var movies = await _movieService.SearchMoviesAsync(filter);
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
