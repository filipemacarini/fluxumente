using FluxuMente.Domain.Entities;

namespace FluxuMente.Application.Abstractions
{
    public interface IOllamaChatService
    {
        Task<bool> VerifyConnectionAsync();
        Task<ChatResponse> GenerateResponseAsync(ChatRequest input);
        Task<List<string>> GetModelNamesAsync();
    }
}
