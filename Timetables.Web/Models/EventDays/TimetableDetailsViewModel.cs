using System;
using System.Collections.Generic;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Models.EventDays
{
    public class TimetableDetailsViewModel
    {
        public string FestivalName { get; set; }
        public Guid FestivalId { get; set; }
        public string TimetableName { get; set; }
        public string TimetableDescription { get; set; }

        public Guid TimetableId { get; set; }

        public DateTime TimetableDate { get; set;}

        public TimetableDetailsViewModel(EventDay timetable)
        {
            TimetableId = timetable.TimetableId;
            TimetableName = timetable.Name;
            TimetableDescription = timetable.Description;
            TimetableDate = timetable.Date;
           
        }
    

  
    }
}