using System;

namespace Timetables.Web.Models
{
    public class CreateInstructorViewModel
    {
        public Guid FestivalId { get; set; }
        public string InstructorName { get; set; }
        public string Subjects { get; set; }

        public CreateInstructorViewModel()
        {

        }

        public CreateInstructorViewModel(Guid festivalId)
        {
            FestivalId = festivalId;
        }
    }
}
