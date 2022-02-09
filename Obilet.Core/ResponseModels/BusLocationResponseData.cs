using Newtonsoft.Json;
using Obilet.Core.Models;
using System.Collections.Generic;

namespace Obilet.Core.ResponseModel
{
    public class BusLocationResponseData: BaseModelResponse
    {
        [JsonProperty("data")]
        public List<DataBusLocation> Data { get; set; }
    }
}
