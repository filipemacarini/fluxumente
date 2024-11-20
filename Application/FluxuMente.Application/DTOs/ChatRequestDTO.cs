namespace FluxuMente.Application.DTOs
{
    public class ChatRequestDTO
    {
        public string Model { get; set; }
        public List<ChatResponseMessageDTO> Messages { get; set; }
        public bool Stream { get; set; }
        public ChatRequestDTO(string model, List<ChatResponseMessageDTO> messages, bool stream)
        {
            Model = model;
            Messages = messages;
            Stream = stream;
        }
    }
}
