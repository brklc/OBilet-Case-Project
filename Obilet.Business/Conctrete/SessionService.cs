using Microsoft.AspNetCore.Http;
using Obilet.Business.Abstract;
using Obilet.Business.Models.General;
using Obilet.Core.Models;
using Obilet.Core.ResponseModel;
using System.Threading.Tasks;

namespace Obilet.Business.Conctrete
{
    public class SessionService : ISessionService
    {
        
        public readonly IRestRequestService _restRequestService;
        public SessionService(IRestRequestService restRequestService)
        {
            _restRequestService = restRequestService;
        }

        public Task<SessionResponseModel> GetSession()
        {
            var session = new Session()
            {
                Application = new Application() { EquipmentId = "DD2A0857-7C7D-4376-A83B-E045435E82BB", Version = "3.1.0.0" },
                Connection = new Connection() { IpAddress = "145.214.41.21" },
                Type = 2 

            };

            var resultData = _restRequestService.PostRequest<SessionResponseModel>(session, "client/getsession");
            return resultData;
        }
    }
}
