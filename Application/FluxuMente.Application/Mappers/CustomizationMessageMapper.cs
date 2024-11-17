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
                Title = message.Title,
                Message = message.Message
            };
        }

        public CustomizationMessage MapToEntity(CustomizationMessageDTO dto)
        {
            return new CustomizationMessage
            {
                Title = dto.Title,
                Message = dto.Message
            };
        }

        public List<CustomizationMessageDTO> MapToDtoList(List<CustomizationMessage> messageList) =>
            messageList.Select(msg => MapToDto(msg)).ToList();

        public List<CustomizationMessage> MapToEntityList(List<CustomizationMessageDTO> dtoList) =>
            dtoList.Select(msg => MapToEntity(msg)).ToList();
    }
}
