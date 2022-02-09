using Newtonsoft.Json;
using System;

namespace Obilet.Core.Models
{
    public class BaseModelRequest
    {
        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }


    }
}
