using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Timetables.Web.Engine.Models;
using Timetables.Web.Engine.Services;
using Timetables.Web.Models;
using Timetables.Web.Models.EventDays;
using Timetables.Web.Routes;

namespace Timetables.Web.Controllers
{
    [Route("{festivalId}/eventdays")]
    public class EventDaysController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFestivalsService _festivalsService;

        public EventDaysController(ILogger<HomeController> logger, IFestivalsService festivalsService)
        {
            _logger = logger;
            _festivalsService = festivalsService;
        }
        [HttpGet, Route("", Name = RouteKeys.EventDays.All)]
        public IActionResult GetEventDaysForFestival(Guid festivalId)
        {
            var festival = _festivalsService.GetFestival(festivalId);

            var viewModel = new EventDaysViewModel(festival);

            return View("AllEventDays", viewModel);

        }
        [HttpGet, Route("timetable-details/{timetableId}", Name = RouteKeys.EventDays.ById)]

        public IActionResult GetTimetableById(Guid timetableId, Guid festivalId)
        {
            var festival = _festivalsService.GetFestival(festivalId);
            var timetable = festival.EventDays.FirstOrDefault(x => x.TimetableId == timetableId);
            var viewModel = new TimetableDetailsViewModel(timetable);

            return View(viewModel);
        }

        [HttpGet, Route("create-timetable", Name = RouteKeys.EventDays.CreateForm)]
        public IActionResult CreateTimetable(Guid festivalId)
        {
            var viewModel = new CreateTimetableViewModel(festivalId);
            return View(viewModel);
        }

        [HttpPost, Route("", Name = RouteKeys.EventDays.Create)]
        public IActionResult AddFestival(CreateTimetableViewModel model)
        {
            var timetable = new EventDay(model.TimetableName);

            var festival = _festivalsService.GetFestival(model.FestivalId);

            festival.EventDays.Add(timetable);

            _festivalsService.SaveFestival(festival);

            return RedirectToRoute(RouteKeys.EventDays.All, model.FestivalId);
        }

    }
}