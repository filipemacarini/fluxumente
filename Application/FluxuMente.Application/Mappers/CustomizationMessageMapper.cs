using FluxuMente.Application.DTOs;
using FluxuMente.Domain.Entities;

namespace FluxuMente.Application.Mappers
{
    public class CustomizationMessageMapper
    {
        public CustomizationMessageDTO MapToDto(CustomizationMessage message)
        {
            return new CustomizationMessageDTO
            {
                Id = message.Id,
                Title = message.Title,
                Content = message.Content
            };
        }

        public CustomizationMessage MapToEntity(CustomizationMessageDTO dto)
        {
            return new CustomizationMessage
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content
            };
        }

        public List<CustomizationMessageDTO> MapToDtoList(List<CustomizationMessage> messageList) =>
            messageList.Select(msg => MapToDto(msg)).ToList();

        public List<CustomizationMessage> MapToEntityList(List<CustomizationMessageDTO> dtoList) =>
            dtoList.Select(msg => MapToEntity(msg)).ToList();
    }
}
