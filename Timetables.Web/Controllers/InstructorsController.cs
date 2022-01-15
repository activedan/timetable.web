using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using Timetables.Web.Engine.Models;
using Timetables.Web.Engine.Services;
using Timetables.Web.Models;
using Timetables.Web.Models.Instructors;
using Timetables.Web.Routes;

namespace Timetables.Web.Controllers
{
    [Route("{festivalId}/instructors")]
    public class InstructorsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFestivalsService _festivalsService;

        public InstructorsController(ILogger<HomeController> logger, IFestivalsService festivalsService)
        {
            _logger = logger;
            _festivalsService = festivalsService;
        }

        // Starting point of the application, loads a list of all previously created Festivals
        [HttpGet, Route("", Name = RouteKeys.Instructors.All)]
        public IActionResult GetInstructorsForFestival(Guid festivalId)
        {
            var festival = _festivalsService.GetFestival(festivalId);
            
            var viewModel = new InstructorsViewModel(festival);

            return View("AllInstructors", viewModel);
        }

        //[HttpGet, Route("{id}", Name = RouteKeys.Instructors.ById)]
        //public IActionResult FestivalById(Guid id)
        //{
        //    var festival = _festivalsService.GetFestival(id);

        //    var viewModel = new FestivalViewModel(festival);

        //    return View("Festival", viewModel);
        //}


        [HttpGet, Route("create-instructor", Name = RouteKeys.Instructors.CreateForm)]
        public IActionResult CreateInstructor(Guid festivalId)
        {
            var viewModel = new CreateInstructorViewModel(festivalId);

            return View(viewModel);
        }

        [HttpPost, Route("", Name = RouteKeys.Instructors.Create)]
        public IActionResult AddFestival(CreateInstructorViewModel model)
        {
            var instructor = new Instructor(model.InstructorName);
            instructor.Subjects = model.Subjects.Split(",").ToList();

            var festival = _festivalsService.GetFestival(model.FestivalId);

            festival.Instructors.Add(instructor);

            _festivalsService.SaveFestival(festival);

            return RedirectToRoute(RouteKeys.Instructors.All, model.FestivalId);
        }



























        
    }
}
