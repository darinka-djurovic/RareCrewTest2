using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RareCrewAssignment.Application.Interfaces;
using RareCrewAssignment.Domain.EmployeeTasks;

namespace RareCrewAssignment.Application.Implementations
{
    public class EmployeeTasksService : IEmployeeTasksService
    {
        private readonly HttpClient _httpClient;

        public EmployeeTasksService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<IEnumerable<EmployeeTask>> GetAll(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EmployeeTask[]>(jsonString);
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}