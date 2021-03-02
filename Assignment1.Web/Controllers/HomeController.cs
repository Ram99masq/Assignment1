using Assignment1.Services.Interface;
using Assignment1.Services.Emp;
using Assignment1.Services.Observer;
using Assignment1.Models;
using Assignment1.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Assignment1.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeProject _projectService;


        public HomeController(ILogger<HomeController> logger, IEmployeeService employeeService, IEmployeeProject projectService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _projectService = projectService;
        }

        public async Task<IActionResult> EmployeeDetails()
        {
            try
            {
                //Employee details
                var employeeDetails = await _employeeService.GetEmployeeDetails();
                return View(employeeDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error when fetching - Employee details : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }
        public async Task<IActionResult> ProjectDetails()
        {
            try
            {
                //Employee details
                var employeeDetails = await _projectService.GetProjectDetails(1);
                return View(employeeDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error when fetching - Project details : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }

        public async Task<IActionResult> AllProjectDetails()
        {
            try
            {
                //Employee details
                var employeeDetails = await _projectService.GetAllProjectDetails();
                return View(employeeDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error when fetching - All Project details : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }
        public async Task<IActionResult> Employees()
        {

            try
            {
                //Employee details
                var employeelist = await _employeeService.GetEmployeeDetails();
                return View(employeelist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error when fetching - All Project details : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }

        }
        public async Task<IActionResult> Index()
        {
            try
            {
                ProductSubject subject = new ProductSubject();
                IObserver observer1 = new Observer("observer1");
                subject.Register(observer1);
                IObserver observer2 = new Observer("observer2");
                subject.Register(observer2);
                //subject.ProductCount++; 
                //Product is added to the inventory and it will notified to all subscribers
                IObserver observer3 = new Observer("observer3");
                subject.Register(observer3);
                subject.Unregister(observer1);
                subject.ProductCount++;

                var observers = subject.GetObservers();           
                return View(observers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error during implementation of Solid principle and  Observer pattern : {ex}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
