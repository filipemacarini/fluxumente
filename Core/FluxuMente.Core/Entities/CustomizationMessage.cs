using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class CustomizationMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
