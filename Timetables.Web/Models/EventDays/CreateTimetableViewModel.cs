using System;

namespace Timetables.Web.Models.EventDays
{
    public class CreateTimetableViewModel
    {
        public Guid FestivalId { get; set; }
        public string TimetableName { get; set; }
        public string Description { get; set; }

        public DateTime TimetableDate { get; set; }
        public CreateTimetableViewModel()
        {

        }

        public CreateTimetableViewModel(Guid festivalId)
        {
            FestivalId = festivalId;
        
        }
    }
}