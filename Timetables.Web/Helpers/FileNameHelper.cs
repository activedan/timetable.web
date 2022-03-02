using System;

namespace Timetables.Web.Helpers
{
    public static class FileNameHelper
    {
        // Eventually this can handle more object types, and I'll adopt a decoration system

        // Not sure on exact properties required so passing entire conversation for now
        public static string BuildFestivalFileName(Guid conversationId)
        {
            var name = $"{Prefix("festival")}{conversationId}";

            return name;
        }


        public static string Prefix(string fileType)
        {
            if (fileType == "festival")
                return "festV1_";

            return "";
        }
    }
}
