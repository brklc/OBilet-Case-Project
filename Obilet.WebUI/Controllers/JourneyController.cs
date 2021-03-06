using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Business.Abstract;
using Obilet.Core.Models;
using Obilet.WebUI.Helpers;
using Obilet.WebUI.ViewModels;
using System;
using System.Threading.Tasks;

namespace Obilet.WebUI.Controllers
{
    public class JourneyController : Controller
    {
        private readonly ISessionService _sessionService;
        private readonly ILocationService _locationService;
        private readonly IJourneyService _journeyService;
        public JourneyController(ISessionService sessionService, ILocationService locationService, IJourneyService journeyService)
        {
            _sessionService = sessionService;
            _locationService = locationService;
            _journeyService = journeyService;
        }
        public async Task<IActionResult> Index()
        {
            if (String.IsNullOrEmpty(SessionHelper.Get(HttpContext.Session, "DeviceId")) && String.IsNullOrEmpty(SessionHelper.Get(HttpContext.Session, "SessionId")))
            {
                var session = await _sessionService.GetSession();

                SessionHelper.Set(HttpContext.Session, "DeviceId", session.Data.DeviceId);
                SessionHelper.Set(HttpContext.Session, "SessionId", session.Data.SessionId);
            }

            var busLocations = _locationService.GetBusLocations(new BusLocation() { DeviceSession = new DeviceSession() { DeviceId = SessionHelper.Get(HttpContext.Session, "DeviceId"), SessionId = SessionHelper.Get(HttpContext.Session, "SessionId") }, Data = null, Date = DateTime.Now, Language = "tr-TR" });

            SelectList busLocationList = new SelectList(busLocations.Result.Data, "Id", "Name");

            BusLocationViewModel busLocationViewModel = new BusLocationViewModel()
            {
                DataSelectList = busLocationList
            };

            return View(busLocationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchTicket(int originId, int destinationId, DateTime date)
        {
            var journeyList = await _journeyService.GetBusJourneys(new BusJourney() { Data = new Data() { OriginId = originId, DestinationId = destinationId, DepartureDate = date }, Date = DateTime.Now, DeviceSession = new DeviceSession() { DeviceId = SessionHelper.Get(HttpContext.Session, "DeviceId"), SessionId = SessionHelper.Get(HttpContext.Session, "SessionId") }, Language = "tr-TR" });

            BusJourneyViewModel busJourneyViewModel = new BusJourneyViewModel()
            {
                Data = journeyList.Data
            };
            return View(busJourneyViewModel);
        }


    }
}
