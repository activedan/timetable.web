using System;

namespace Timetables.Web.Engine.Models
{
    public class SessionSlot
    {
        public Guid SessionSlotId { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public int SessionLengthInMinutes { get; set; }
    }
}

