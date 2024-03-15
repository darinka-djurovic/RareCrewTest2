using Microsoft.Extensions.DependencyInjection;
using RareCrewAssignment.Application;

namespace RareCrewAssignment.Website
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddSystemServices(this IServiceCollection services)
        {
            return services.AddServices();
        }
    }
}