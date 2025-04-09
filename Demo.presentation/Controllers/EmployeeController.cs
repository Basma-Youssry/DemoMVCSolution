using Demo.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService) : Controller
    {
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();

            return View(Employees);
        }
    }
}
