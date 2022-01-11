using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{
    public class Instructors
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public List<string> Subjects { get; set; }
    }
}

