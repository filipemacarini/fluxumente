using FluxuMente.Application.Abstractions;
using FluxuMente.Domain.Entities;
using System.Text.Json;
using System.Text;

namespace FluxuMente.Application.Implementations
{
    public class OllamaChatService : IOllamaChatService
    {
        private readonly HttpClient _httpClient;

        public OllamaChatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> VerifyConnectionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_httpClient.BaseAddress?.ToString());
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ChatResponse> GenerateResponseAsync(ChatRequest request)
        {
            var requestJson = JsonSerializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/chat", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseDeserialized = JsonSerializer.Deserialize<ChatResponse>(responseString);

            return responseDeserialized;
        }

        public async Task<List<string>> GetModelNamesAsync()
        {
            var response = await _httpClient.GetAsync("/api/tags");
            var responseString = await response.Content.ReadAsStringAsync();
            var models = JsonSerializer.Deserialize<ModelsResponse>(responseString);
            var modelNames = models.Models.Select(model => model.Name).ToList();

            return modelNames;
        }
    }
}
