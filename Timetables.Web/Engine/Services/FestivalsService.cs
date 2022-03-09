using System;
using System.Collections.Generic;
using Timetables.Web.Engine.Repos;
using Timetables.Web.Engine.Models;


namespace Timetables.Web.Engine.Services
{

    public interface IFestivalsService
    {
        Festival GetFestival(Guid festivalId);
        List<Festival> GetAllFestivals();

        void SaveFestival(Festival festival);
        void DeleteFestival(Guid festivalId);

        void RemoveInstructor(Guid festivalId, Guid instructorId);
    }

    public class FestivalsService : IFestivalsService
    {
        private readonly IFestivalsRepo _repo;

        public FestivalsService(IFestivalsRepo repo)
        {
            _repo = repo;
        }

        public List<Festival> GetAllFestivals()
        {
            return _repo.GetAllFestivals();
        }

        public Festival GetFestival(Guid festivalId)
        {
            return _repo.GetFestival(festivalId);
        }

        public void SaveFestival(Festival festival)
        {
            _repo.SaveFestival(festival);
        }

        public void DeleteFestival(Guid festivalId)
        {
            _repo.DeleteFestival(festivalId);
        }

        public void RemoveInstructor(Guid festivalId, Guid instructorId)
        {
            var festival = _repo.GetFestival(festivalId);
            
            festival.Instructors.RemoveAll(x => x.InstructorId == instructorId);
           
            _repo.SaveFestival(festival);
        }
    }
}
