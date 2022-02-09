using Newtonsoft.Json;
using Obilet.Core.Models;
using System.Collections.Generic;

namespace Obilet.Core.ResponseModel
{
    public class BusJourneyResponseData : BaseModelResponse
    {
        [JsonProperty("data")]
        public List<BusJourneyData> Data { get; set; }
    }
}
