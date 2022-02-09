using Obilet.Business.Abstract;
using Obilet.Core.Models;
using Obilet.Core.ResponseModel;
using System.Threading.Tasks;

namespace Obilet.Business.Conctrete
{
    public class JourneyService : IJourneyService
    {
        public readonly IRestRequestService _restRequestService;
        public JourneyService(IRestRequestService restRequestService)
        {
            _restRequestService = restRequestService;
        }
        public Task<BusJourneyResponseData> GetBusJourneys(BusJourney busJourney)
        {
            busJourney = new BusJourney()
            {
                DeviceSession = new DeviceSession() { DeviceId = busJourney.DeviceSession.DeviceId, SessionId = busJourney.DeviceSession.SessionId },
                Data = new Data() { OriginId = busJourney.Data.OriginId, DestinationId = busJourney.Data.DestinationId, DepartureDate = busJourney.Data.DepartureDate},
                Date = busJourney.Date,
                Language = busJourney.Language
            };
            var resultData = _restRequestService.PostRequest<BusJourneyResponseData>(busJourney, "journey/getbusjourneys");

            return resultData;
        }
    }
}
