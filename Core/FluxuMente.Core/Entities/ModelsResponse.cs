using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class ModelsResponse
    {
        [JsonPropertyName("models")]
        public List<ModelsResponseModel> Models { get; set; }
    }
}
