using FluxuMente.Application.DTOs;

namespace FluxuMente.Application.Abstractions
{
    public interface ICustomizationMessageService
    {
        Task<List<CustomizationMessageDTO>> GetAllMessagesAsync();
        Task AddMessageAsync(CustomizationMessageDTO message);
        Task RemoveMessageAsync(string title);
        Task UpdateMessageAsync(CustomizationMessageDTO messageUpdated);
    }
}
