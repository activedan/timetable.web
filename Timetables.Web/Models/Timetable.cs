using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timetables.Web.Models
{
    public class Festival
    {
        public Guid FestivalId { get; set; }
        public string Name { get; set; }
        public List<Instructors> Instructors { get; set; }
        public List<Timetable> EventDays { get; set; }
    }

    public class Timetable
    {
        public Guid TimetableId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<SessionSlot> SessionSlots { get; set; }
        public List<Track> Tracks { get; set; }
        
    }

    public class Track
    {
        public Guid TrackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TrackOrder { get; set; }
        public List<Session> Sessions { get; set; }
        public List<string> Facilities { get; set; }
    }

    public class SessionSlot
    {
        public Guid SessionSlotId { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int SessionLengthInMinutes { get; set; }
    }

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

    public class Instructors
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public List<string> Subjects { get; set; }
    }

    public class SessionType
    {
        public Guid SessionTypeId { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
    }
}

