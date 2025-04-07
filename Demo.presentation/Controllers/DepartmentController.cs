using Demo.BusinessLogic.DataTransfareObject.DepartmentDto;
using Demo.BusinessLogic.DataTransfareObject.DepartmentDto.DepartmentDto;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.presentation.ViewModels.DepartmentViewModel;
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



        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();

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

        #region Edit Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.DateOfCreation
            };
            return View(departmentViewModel);

        }



        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDto()
                    {
                        Id = id,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.DateOfCreation
                    };

                    var Result = _departmentService.UpdateDepartment(UpdatedDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department is not Updated");
                    }
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
                        return View("ErrorView", ex);
                    }
                }

            }
            return View(viewModel);

        }
        #endregion

        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();

        //    return View(department);


        //}


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Deperatment");
                    return RedirectToAction(nameof(Delete), new { id = id });
                }
            }

            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    //1. Development => Log Error in console and return same view Error message.
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //2. Deployment => Log Error in file | Table in Database and return Error view.
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }

            #endregion
        }
    }
}
