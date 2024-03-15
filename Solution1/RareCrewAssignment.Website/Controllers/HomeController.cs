using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RareCrewAssignment.Application.Interfaces;
using RareCrewAssignment.Website.Models;

namespace RareCrewAssignment.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
        
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeTasksService _employeeTasksService;

        public HomeController(ILogger<HomeController> logger, IEmployeeTasksService employeeTasksService)
        {
            _logger = logger;
            _employeeTasksService = employeeTasksService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await GetEmployeesViewModel();
            
            return View(viewModel);
        }

        private async Task<EmployeeTasksViewModel> GetEmployeesViewModel()
        {
            return new EmployeeTasksViewModel
            {
                EmpployeeTasks = (await _employeeTasksService.GetAll(apiUrl))?.Where(x => x.DeletedOn is null).GroupBy(x => x.EmployeeName).Select(x=>new EmployeeTaskViewModel
                    {
                        EmployeeName = x.Key ?? "Employee without name",
                        TotalHoursWorked = Math.Round(x.Sum(e=>(e.EndTimeUtc-e.StarTimeUtc).TotalHours),2)
                    })
                    .ToList().OrderBy(x => x.TotalHoursWorked)
            };
            
        }
        
    }
}