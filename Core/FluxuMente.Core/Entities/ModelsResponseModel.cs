using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class ModelsResponseModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("digest")]
        public string Digest { get; set; }

        [JsonPropertyName("details")]
        public ChatResponseDetails Details { get; set; }
    }
}
