using System;
using System.Collections.Generic;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Models.Instructors
{
    public class InstructorsViewModel
    {
        public string FestivalName { get; set; }
        public Guid FestivalId { get; set; }
        public List<Instructor> Instructors { get; set; }

        public InstructorsViewModel(Festival festival)
        {
            FestivalName = festival.Name;
            FestivalId = festival.FestivalId;
            Instructors = festival.Instructors;
        }
    }
}
