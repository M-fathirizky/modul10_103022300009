using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300009.Controllers;

[ApiController]
[Route("[controller]")]

public class WeatherForecastController : ControllerBase
{
    private static List<Movie> moviesList = new List<Movie>()
    {
        new Movie("The Shawshank Redemption", "Frank Darabont", new List<string> { "Tim Robbins","Morgan Freeman","Bob Gunton" }, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
        new Movie("the Godfather", "Francis Ford Coppola", new List < string > { "Tim Robbins", "Morgan Freeman", "Bob Gunton" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
        new Movie("the dark Knight", "Christopher Nolan", new List<string> { "Christian Bale","Heath Ledger","Aaron Eckhart" }, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."),
    };

    [HttpGet]
    public IEnumerable<Movie> Get()
    {
        return moviesList;
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovieByIndex(int index)
    {
        if (index < 0 || index >= moviesList.Count)
        {
            return NotFound("Movie not found");
        }
        return Ok(moviesList[index]);
    }

    [HttpPost]
    public ActionResult<Movie> AddMovie([FromBody] Movie movie)
    {
        if (movie == null)
        {
            return BadRequest("Invalid movie data");
        }
        moviesList.Add(movie);
        return CreatedAtAction(nameof(GetMovieByIndex), new { index = moviesList.Count - 1 }, movie);
    }

    [HttpDelete("{index}")]
    public ActionResult DeleteMovie(int index)
    {
        if (index < 0 || index >= moviesList.Count)
        {
            return NotFound("Movie not found");
        }
        moviesList.RemoveAt(index);
        return NoContent();
    }

}
/*
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
*/