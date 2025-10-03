using Newtonsoft.Json;
using System.Text.Json;

namespace RapidApiConsume.Models
{
    public class BookingApiLocationSearchViewModel
    {

        public class DestinationResult
        {
            [JsonProperty("destinationId")]
            public string DestinationId { get; set; }
            [JsonProperty("ufi")]
            public int? Ufi { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class DestinationResponse
        {
            [JsonProperty("results")]
            public List<DestinationResult> Results { get; set; }
        }
    }

}

