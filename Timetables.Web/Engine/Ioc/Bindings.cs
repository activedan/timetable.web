using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timetables.Web.Engine.Repos;
using Timetables.Web.Engine.Services;

namespace Timetables.Web.Engine.Ioc
{
    public static class IocExtensions
    {
        public static IServiceCollection RegisterEngine(this IServiceCollection services, IConfiguration config)
        {

            services.AddSingleton<IFestivalsRepo, FestivalsFileRepo>();

            services.AddSingleton<IFestivalsService, FestivalsService>();

            return services;

        }
    }
}
