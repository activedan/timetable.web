using System;
using System.Collections.Generic;

namespace Timetables.Web.Engine.Models
{
    public class Track
    {
        public Guid TrackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TrackOrder { get; set; }
        public List<Session> Sessions { get; set; }
        public List<string> Facilities { get; set; }
    }
}

