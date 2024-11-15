using System.Text.Json.Serialization;

namespace FluxuMente.Domain.Entities
{
    public class ChatResponseDetails
    {
        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("family")]
        public string Family { get; set; }

        [JsonPropertyName("families")]
        public List<string> Families { get; set; }

        [JsonPropertyName("parameter_size")]
        public string ParameterSize { get; set; }

        [JsonPropertyName("quantization_level")]
        public string QuantizationLevel { get; set; }
    }
}
