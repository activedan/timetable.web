using System;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Models
{
    public class FestivalViewModel
    {
        public Guid FestivalId { get; set; }
        public string FestivalName { get; set; }

        public FestivalViewModel(Festival festival)
        {
            FestivalId = festival.FestivalId;
            FestivalName = festival.Name;
        }
    }
}
