using FluxuMente.Application.DTOs;
using FluxuMente.Domain.Entities;

namespace FluxuMente.Application.Mappers
{
    public static class ChatResponseMessageMapper
    {
        public static DTOs.ChatResponseMessageDTO MapToDto(ChatResponseMessage message) =>
            new DTOs.ChatResponseMessageDTO(message.Role, message.Content);

        public static ChatResponseMessage MapToEntity(DTOs.ChatResponseMessageDTO dto) =>
            new ChatResponseMessage(dto.Role, dto.Content);

        public static List<ChatResponseMessageDTO> MapToDtoList(List<ChatResponseMessage> messageList) =>
            messageList.Select(msg => MapToDto(msg)).ToList();

        public static List<ChatResponseMessage> MapToEntityList(List<ChatResponseMessageDTO> dtoList) =>
            dtoList.Select(msg => MapToEntity(msg)).ToList();
    }
}
