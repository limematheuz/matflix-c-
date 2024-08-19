using System.Text.Json;
using MatFlix.Interfaces;
using MatFlix.Services;

namespace MatFlix.Repositories
{
    public class ImdbRepository : IImdbRepository
    {
        private readonly ApiService _apiService;
        private readonly ILogger<ImdbRepository> _logger;

        public ImdbRepository(ApiService apiService, ILogger<ImdbRepository> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<List<JsonElement>> GetUpcomingMoviesAsync()
        {
            _logger.LogInformation("Fetching upcoming movies.");
            var response = await _apiService.GetApiDataAsync("https://api.themoviedb.org/3/movie/upcoming?language=en-US&page=1");

            if (response == null || !response.RootElement.TryGetProperty("results", out var results))
            {
                _logger.LogWarning("No upcoming movies found.");
                return new List<JsonElement>();
            }

            return results.EnumerateArray().ToList();
        }

        public async Task<List<JsonElement>> GetPopularMoviesAsync()
        {
            _logger.LogInformation("Fetching popular movies.");
            var response = await _apiService.GetApiDataAsync("https://api.themoviedb.org/3/movie/popular?language=en-US&page=1");

            if (response == null || !response.RootElement.TryGetProperty("results", out var results))
            {
                _logger.LogWarning("No popular movies found.");
                return new List<JsonElement>();
            }

            return results.EnumerateArray().ToList();
        }
    }
}