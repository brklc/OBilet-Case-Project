using Obilet.Core.Models;
using Obilet.Core.ResponseModel;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IJourneyService
    {
        Task<BusJourneyResponseData> GetBusJourneys(BusJourney busJourney);
    }
}
