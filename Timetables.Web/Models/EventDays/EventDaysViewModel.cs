using System;
using System.Collections.Generic;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Models
{
    public class EventDaysViewModel
    {
        public string FestivalName { get; set; }

        public Guid FestivalId { get; set; }
        public List<EventDay> EventDays { get; set; }


        public EventDaysViewModel(Festival festival)
        {
            FestivalName = festival.Name;
            FestivalId = festival.FestivalId;
            EventDays = festival.EventDays;
        }
    }
}