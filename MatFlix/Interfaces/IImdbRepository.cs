using System.Text.Json;

namespace MatFlix.Interfaces
{
    public interface IImdbRepository
    {
        Task<List<JsonElement>> GetUpcomingMoviesAsync();
        Task<List<JsonElement>> GetPopularMoviesAsync();
    }
}