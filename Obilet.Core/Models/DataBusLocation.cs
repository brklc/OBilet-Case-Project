using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class DataBusLocation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
}