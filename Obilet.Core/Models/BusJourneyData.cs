using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class BusJourneyData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("partner-name")]
        public string PartnerName { get; set; }

        [JsonProperty("origin-location")]
        public string OriginLocation { get; set; }

        [JsonProperty("journey")]
        public Journey Journey { get; set; }

        [JsonProperty("destination-location")]
        public string DestinationLocation { get; set; }

    }
}
