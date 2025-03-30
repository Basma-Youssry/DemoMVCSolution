using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Demo.presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService) : Controller
    {
        // BaseUrl/Depratment/Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _departmentService.GetAllDepartments();
            return View(Departments);
        }
    }
}
