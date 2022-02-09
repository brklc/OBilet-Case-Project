using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class BusJourney: BaseModelRequest
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
