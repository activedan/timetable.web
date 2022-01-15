using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{
    public class Festival
    {
        public Guid FestivalId { get; set; }
        public string Name { get; set; }
        public List<Instructor> Instructors { get; set; }
        public List<Timetable> EventDays { get; set; }

        public Festival(string name)
        {
            FestivalId = Guid.NewGuid();
            Name = name;
            Instructors = new List<Instructor>();
            EventDays = new List<Timetable>();
        }
    }
}

