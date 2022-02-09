using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class BusLocation: BaseModelRequest
    {
        [JsonProperty("data")]
        public string Data { get; set; }

    }
}
