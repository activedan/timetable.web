using System;
using System.Collections.Generic;
using System.Linq;
using Timetables.Web.Engine.Models;

namespace Timetables.Web.Engine.Repos
{
    public interface IFestivalsRepo
    {
        Festival GetFestival(Guid festivalId);
        List<Festival> GetAllFestivals();

        void SaveFestival(Festival festival);
    }

    public class FestivalsRepo : IFestivalsRepo
    {
        private List<Festival> _tempRepo;

        public FestivalsRepo()
        {
            _tempRepo = new List<Festival>();
        }

        public List<Festival> GetAllFestivals()
        {
            return _tempRepo;
        }

        public Festival GetFestival(Guid festivalId)
        {
            return _tempRepo.First(x => x.FestivalId == festivalId);
        }

        public void SaveFestival(Festival festival)
        {
            if (_tempRepo.Any(x => x.FestivalId == festival.FestivalId))
            {
                _tempRepo.RemoveAll(x => x.FestivalId == festival.FestivalId);
            }

            _tempRepo.Add(festival);
        }
    }
}
