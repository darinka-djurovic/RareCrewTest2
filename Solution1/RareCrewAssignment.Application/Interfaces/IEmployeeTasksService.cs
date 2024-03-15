using System.Collections.Generic;
using System.Threading.Tasks;
using RareCrewAssignment.Domain.EmployeeTasks;

namespace RareCrewAssignment.Application.Interfaces
{
    public interface IEmployeeTasksService
    {
        public Task<IEnumerable<EmployeeTask>> GetAll(string apiUrl);
    }
}