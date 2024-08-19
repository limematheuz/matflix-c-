﻿using System.Text.Json;

namespace MatFlix.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _bearerToken;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _bearerToken = configuration["TmdbBearerToken"];
        }

        public async Task<JsonDocument> GetApiDataAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_bearerToken}");

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonDocument.Parse(content);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.ReasonPhrase}, Content: {errorContent}");
            }
        }
    }
}