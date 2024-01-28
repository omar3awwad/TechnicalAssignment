using Newtonsoft.Json;

namespace TechnicalAssignment.Api.Models.Integration
{
    public class IntegrationModelsResponse
    {
        [JsonProperty("Count")]
        public int Count { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("SearchCriteria")]
        public string SearchCriteria { get; set; }

        [JsonProperty("Results")]
        public List<ModelDetails> Results { get; set; }
    }

    public class ModelDetails
    {
        [JsonProperty("Make_ID")]
        public int Make_ID { get; set; }

        [JsonProperty("Make_Name")]
        public string Make_Name { get; set; }

        [JsonProperty("Model_ID")]
        public int Model_ID { get; set; }

        [JsonProperty("Model_Name")]
        public string Model_Name { get; set; }
    }
}
