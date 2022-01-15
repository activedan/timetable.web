using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public List<string> Subjects { get; set; }

        public Instructor(string name)
        {
            InstructorId = Guid.NewGuid();
            Name = name;
            Subjects = new List<string>();
        }
    }
}

