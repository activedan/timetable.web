using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Timetables.Web.Engine.Models;
using Timetables.Web.Helpers;

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
            _tempRepo.Add(festival);
        }
    }

    public class FestivalsFileRepo : IFestivalsRepo
    {
        const string _dataFolder = "Festivals";
        string _directory;

        public FestivalsFileRepo()
        {
            Setup(_dataFolder);
        }

        public List<Festival> GetAllFestivals()
        {
            var festivals = new List<Festival>();

            var fileNames = Directory.GetFiles(_directory);

            foreach (var fileName in fileNames)
            {
                if (Path.GetFileName(fileName).StartsWith(FileNameHelper.Prefix("festival")))
                {
                    var festivalData = ReadFile(fileName);

                    if (festivalData != null)
                        festivals.Add(festivalData);
                }
            }

            return festivals;
        }

        public Festival GetFestival(Guid festivalId)
        {
            return ReadFile(FileNameHelper.BuildFestivalFileName(festivalId));
        }

        public void SaveFestival(Festival festival)
        {
            WriteFile(festival);
        }

        private Festival ReadFile(string fileName)
        {
            var data = File.ReadAllText(Path.Combine(_directory, fileName));

            var convo = JsonConvert.DeserializeObject<Festival>(data);

            return convo;
        }

        private void WriteFile(Festival data)
        {
            var fileName = FileNameHelper.BuildFestivalFileName(data.FestivalId);

            using (StreamWriter file = File.CreateText($"{Path.Combine(_directory, fileName)}"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
            }
        }

        private void Setup(string folderName)
        {
            _directory = Path.Combine(Directory.GetCurrentDirectory(), "FileStore", folderName);

            if (!Directory.Exists(_directory))
                Directory.CreateDirectory(_directory);
        }
    }
}
