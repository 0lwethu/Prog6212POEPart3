using System.Net.Http.Json;

namespace RaceDayMVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("API GET {Endpoint} returned status {StatusCode}", endpoint, response.StatusCode);
                    return default;
                }
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling API GET {Endpoint}", endpoint);
                return default;
            }
        }

        public async Task<bool> PostAsync<TInput>(string endpoint, TInput data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(endpoint, data);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling API POST {Endpoint}", endpoint);
                return false;
            }
        }
    }
}