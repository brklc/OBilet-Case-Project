using Newtonsoft.Json;

namespace Obilet.Core.Models
{
    public class Application
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }
    }
}