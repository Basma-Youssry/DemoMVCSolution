using Demo.BusinessLogic.DataTransfareObject.DepartmentsDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo.presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService, 
        ILogger<EmployeeController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();

            return View(Employees);
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid) //Server side validation
            {
                try
                {
                    int Result = _employeeService.CreateEmployee(employeeDto);

                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department can't be created");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        //1. Development => Log Error in console and return same view Error message.
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2. Deployment => Log Error in file | Table in Database and return Error view.
                        _logger.LogError(ex.Message);
                    }
                }
            }

            return View(employeeDto);
        }
        #endregion
    }
}
