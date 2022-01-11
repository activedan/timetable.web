using System.Collections.Generic;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Models
{
    public class HomeViewModel
    {
        public List<Festival> Festivals { get; set; }

        public HomeViewModel()
        {
            Festivals = new List<Festival>();
        }

        public HomeViewModel(List<Festival> festivals)
        {
            Festivals = festivals;
        }
    }
}
