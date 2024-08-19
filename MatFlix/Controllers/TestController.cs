using MatFlix.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        public IActionResult GetTestData()
        {
            var testData = new List<MovieSummary>
            {
                new MovieSummary { Id = 1, Title = "Test Movie", Overview = "Test Overview", ReleaseDate = "2023-01-01" }
            };
            return Ok(testData);
        }
    }
}
