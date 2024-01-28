using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TechnicalAssignment.Api.Models
{
    public class ModelsResponse
    {
        [JsonPropertyName("Models")]
        public IEnumerable<string> Models { get; set; } = Enumerable.Empty<string>();
    }
}
