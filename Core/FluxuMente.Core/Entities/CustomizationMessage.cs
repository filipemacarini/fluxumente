using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class CustomizationMessage
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
