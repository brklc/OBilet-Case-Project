using Newtonsoft.Json;
using Obilet.Core.Models;

namespace Obilet.Core.ResponseModel
{
    public class SessionResponseModel: BaseModelResponse
    {
        [JsonProperty("data")]
        public SessionData Data { get; set; }
    }
}
