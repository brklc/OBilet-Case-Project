using Obilet.Business.Abstract;
using Obilet.Core.Models;
using Obilet.Core.ResponseModel;
using System.Threading.Tasks;

namespace Obilet.Business.Conctrete
{
    public class LocationService : ILocationService
    {
        public readonly IRestRequestService _restRequestService;
        public readonly ISessionService _sessionService;
        public LocationService(IRestRequestService restRequestService, ISessionService sessionService)
        {
            _restRequestService = restRequestService;
            _sessionService = sessionService;
        }
        public Task<BusLocationResponseData> GetBusLocations(BusLocation busLocation)
        {
           busLocation = new BusLocation()
            {
                DeviceSession = new DeviceSession() { DeviceId = busLocation.DeviceSession.DeviceId, SessionId = busLocation.DeviceSession.SessionId },
                Data = busLocation.Data,
                Date = busLocation.Date,
                Language = busLocation.Language
            };

           var resultData =  _restRequestService.PostRequest<BusLocationResponseData>(busLocation, "location/getbuslocations");

            return resultData;
        }
    }
}
