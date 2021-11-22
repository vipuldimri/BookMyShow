
using BookMyShow.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ISearchMovies _searchMovies;
        private readonly ILoggerManager _logger;
        public MovieController(ISearchMovies searchMovies, ILoggerManager logger)
        {
            _searchMovies = searchMovies;
            _logger = logger;
        }


        // Get
        // api/Movie/City/{cityId}
        /// <summary>
        /// Get Cart 
        /// <returns>A response contains Cart</returns>
        /// <response code="200">If everyting is fine return Shops list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("cityId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetMoviesByCity(int cityId)
        {
            return Ok(_searchMovies.GetMoviesByCity(cityId));
        }

        // Get
        // api/Movie/City/{cityId}
        /// <summary>
        /// Get Cart 
        /// <returns>A response contains Cart</returns>
        /// <response code="200">If everyting is fine return Shops list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("movieId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetCinemaByMovie(int movieId)
        {
            return Ok(_searchMovies.GetCinemaByMovie(movieId));
        }
    }
}
