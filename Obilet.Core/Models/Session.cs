using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class Session
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("connection")]
        public Connection Connection { get; set; }

        [JsonProperty("application")]
        public Application Application { get; set; }
    }
}
