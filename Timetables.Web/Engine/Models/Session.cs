using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{
    public class Session
    {
        public Guid SessionId { get; set; }
        public Guid TrackId { get; set; }
        public SessionType SessionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Instructors> Facilitators { get; set; }
        
        public int? Capacity { get; set; }
        public bool RequiresRegistration { get; set; }

        public List<Guid> ParticipantIds { get; set; }
        
    }
}

