using Demo.BusinessLogic.DataTransfareObject;
using Demo.BusinessLogic.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace Demo.presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,
                                     ILogger<DepartmentController> _logger, IWebHostEnvironment _environment) : Controller
    {
        
        // BaseUrl/Depratment/Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _departmentService.GetAllDepartments();
            return View(Departments);
        }

        [HttpGet]
        public IActionResult Create() => View();

        #region Create Department
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto departmentdto)
        {
            if (ModelState.IsValid) //Server side validation
            {
                try
                {
                    int Result = _departmentService.CreateDepartment(departmentdto);

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

            //Will excute for every statments
            return View(departmentdto);

        }
        #endregion


        #region Details of department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest(); //400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound(); //404
            return View(department);
        }

        #endregion
    }
}
