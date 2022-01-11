using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Timetables.Web.Engine.Models;
using Timetables.Web.Engine.Services;
using Timetables.Web.Models;
using Timetables.Web.Routes;

namespace Timetables.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFestivalsService _festivalsService;

        public HomeController(ILogger<HomeController> logger, IFestivalsService festivalsService)
        {
            _logger = logger;
            _festivalsService = festivalsService;
        }

        // Starting point of the application, loads a list of all previously created Festivals
        [HttpGet, Route("", Name = RouteKeys.Festival.All)]
        public IActionResult Index()
        {
            var allFestivals = _festivalsService.GetAllFestivals();

            var viewModel = new HomeViewModel(allFestivals);

            return View(viewModel);
        }

        [HttpGet, Route("festival/{id}", Name = RouteKeys.Festival.ById)]
        public IActionResult FestivalById(Guid id)
        {
            var festival = _festivalsService.GetFestival(id);

            var viewModel = new FestivalViewModel(festival);

            return View("Festival", viewModel);
        }

        [HttpGet, Route("create-festival", Name = RouteKeys.Festival.CreateForm)]
        public IActionResult CreateFestival()
        {
            return View();
        }

        [HttpPost, Route("festival", Name = RouteKeys.Festival.Create)]
        public IActionResult AddFestival(CreateFestivalViewModel model)
        {
            var festival = new Festival(model.FestivalName);

            _festivalsService.SaveFestival(festival);

            return RedirectToRoute(RouteKeys.Festival.All);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
