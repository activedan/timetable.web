using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Timetables.Web.Engine.Services;
using Timetables.Web.Models.Instructors;

namespace Timetables.Web.ViewComponents
{
    [ViewComponent(Name = "Instructors")]
    public class InstructorsViewComponent : ViewComponent
    {
        private readonly IFestivalsService _festivalsService;

        public InstructorsViewComponent(IFestivalsService festivalsService)
        {
            _festivalsService = festivalsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid festivalId)
        {
            var festival = _festivalsService.GetFestival(festivalId);

            var viewModel = new InstructorsViewModel(festival);

            return View("_Instructors", viewModel);
        }
    }
}
