using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{

    public class EventDay
    {
        public Guid TimetableId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<SessionSlot> SessionSlots { get; set; }
        public List<Track> Tracks { get; set; }

        public EventDay(string name)
        {
            TimetableId = Guid.NewGuid();
            Name = name;
            Description = name;
        }
        
    }
}

