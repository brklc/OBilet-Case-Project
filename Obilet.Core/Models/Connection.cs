using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class Connection
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }
    }
}