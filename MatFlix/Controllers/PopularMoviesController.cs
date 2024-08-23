using MatFlix.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularMoviesController : ControllerBase
    {
        private readonly IImdbRepository _repository;

        public PopularMoviesController(IImdbRepository imdbRepository)
        {
            _repository = imdbRepository;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPopularMovies()
        {
            var popularMovies = await _repository.GetPopularMoviesAsync();
            if (popularMovies == null || !popularMovies.Any())
            {
                return NotFound("No popular movies found.");
            }

            return Ok(popularMovies);
        }
    }
}