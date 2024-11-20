namespace FluxuMente.Application.DTOs
{
    public class ChatResponseMessageDTO
    {
        public string Role { get; set; }
        public string Content { get; set; }

        public ChatResponseMessageDTO(string role, string content)
        {
            Role = role;
            Content = content;
        }
    }
}
