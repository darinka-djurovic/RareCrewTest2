using Microsoft.Extensions.DependencyInjection;
using RareCrewAssignment.Application.Implementations;
using RareCrewAssignment.Application.Interfaces;

namespace RareCrewAssignment.Application
{
    public static class DiConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddTransient<IEmployeeTasksService, EmployeeTasksService>();
        }
    }
}