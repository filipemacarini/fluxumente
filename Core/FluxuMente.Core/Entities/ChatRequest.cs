using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public List<ChatResponseMessage> Messages { get; set; }

        [JsonPropertyName("stream")]
        public bool Stream { get; set; }
    }
}
