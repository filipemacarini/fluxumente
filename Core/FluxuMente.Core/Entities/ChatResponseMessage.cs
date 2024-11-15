using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class ChatResponseMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public ChatResponseMessage(string role, string content)
        {
            Role = role;
            Content = content;
        }
    }
}
