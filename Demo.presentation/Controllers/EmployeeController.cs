using Demo.BusinessLogic.DataTransfareObject.DepartmentsDto;
using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Modules.Shared.Enums;
using Demo.presentation.ViewModels.DepartmentViewModel;
using Demo.presentation.ViewModels.EmployeeViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Demo.presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService, 
        ILogger<EmployeeController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employees = _employeeService.GetAllEmployees(EmployeeSearchName);

            return View(Employees);
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create() {
           return View();
        } 

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid) //Server side validation
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        Email = employeeViewModel.Email,
                        HiringDate = employeeViewModel.HiringDate,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary,
                        IsActive = employeeViewModel.IsActive,
                        Gender = employeeViewModel.Gender,
                        EmployeeType = employeeViewModel.EmployeeType,
                        DepartmentId = employeeViewModel.DepartmentId
                    };
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

            return View(employeeViewModel);
        }
        #endregion

        #region Details of Employee
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(employee);
        }
        #endregion

        #region Edit Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            var employeeDto = new EmployeeViewModel()
            {
               
                Name = employee.Name,
                Salary = employee.Salary,
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                HiringDate = employee.HiringDate,
                Gender = Enum.Parse<Gender>(employee.Gender),
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                DepartmentId = employee.DepartmentId
                
            };

            return View(employeeDto);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id, EmployeeViewModel viewModel)
        {
            if (!id.HasValue) return BadRequest();

            if (ModelState.IsValid) //return View(employeeDto);

            try
            {
                    var employeeDto = new UpdatedEmployeeDto()
                    {
                        Id = id.Value,  //Take of from Route
                        Name = viewModel.Name,
                        Age = viewModel.Age,
                        Address = viewModel.Address,
                        Email = viewModel.Email,
                        HiringDate = viewModel.HiringDate,
                        PhoneNumber = viewModel.PhoneNumber,
                        Salary = viewModel.Salary,
                        IsActive = viewModel.IsActive,
                        Gender = viewModel.Gender,
                        EmployeeType = viewModel.EmployeeType,
                        DepartmentId = viewModel.DepartmentId
                    };

                    var Result = _employeeService.UpdateEmployee(employeeDto);


                if (Result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Employee is not updated");
                    //return View(employeeDto);    
            }
            catch(Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    //return View(employeeDto);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }


            return View(viewModel);

        }

        #endregion

        #region Delete Employee
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                bool Deleted = _employeeService.DeleteEmployee(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not Deleted");
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

        }




        #endregion
    }
}
