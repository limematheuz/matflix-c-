using MatFlix.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingMoviesController : ControllerBase
    {
        private readonly IImdbRepository _repository;

        public UpcomingMoviesController(IImdbRepository imdbRepository)
        {
            _repository = imdbRepository;
        }
        // [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUpcomingMovies()
        {
            var upcomingMovies = await _repository.GetUpcomingMoviesAsync();
            if (upcomingMovies == null || !upcomingMovies.Any())
            {
                return NotFound("No upcoming movies found.");
            }

            return Ok(upcomingMovies);
        }
    }
}