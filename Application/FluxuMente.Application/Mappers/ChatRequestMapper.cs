using FluxuMente.Application.DTOs;
using FluxuMente.Domain.Entities;

namespace FluxuMente.Application.Mappers
{
    public static class ChatRequestMapper
    {
        public static ChatRequestDTO MapToDto(ChatRequest chatRequest)
        {
            return new ChatRequestDTO(chatRequest.Model, ChatResponseMessageMapper.MapToDtoList(chatRequest.Messages), chatRequest.Stream);
        }

        public static ChatRequest MapToEntity(ChatRequestDTO dto)
        {
            return new ChatRequest
            {
                Model = dto.Model,
                Messages = ChatResponseMessageMapper.MapToEntityList(dto.Messages),
                Stream = dto.Stream
            };
        }
    }
}
