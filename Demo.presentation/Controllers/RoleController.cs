using Demo.presentation.ViewModels.RolesViewModel;
using Demo.presentation.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.presentation.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager,
                                    ILogger<EmployeeController> _logger,
                                  IWebHostEnvironment _environment) : Controller
    {
        #region Index
        //Get All Users
        [HttpGet]
        public IActionResult Index(string searchValue)
        {
            var rolesQuery = _roleManager.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
                rolesQuery = rolesQuery.Where(R => R.Name.ToLower().Contains(searchValue.ToLower()));

            var rolesList = rolesQuery.Select(
               R => new RoleViewModel
                {
                   Id = R.Id,
                   RoleName = R.Name
                });

            return View(rolesList);
        }

        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
               await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = roleViewModel.RoleName
                });
                return RedirectToAction(nameof(Index));
            }
            return View(roleViewModel);
        }
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(string? id)
        {
            if (id is null) return BadRequest(); //400

            var Role = _roleManager.FindByIdAsync(id).Result;
            if (Role is null) return NotFound(); //404

            var RoleViewModel = new RoleViewModel()
            {
               Id = Role.Id,
               RoleName= Role.Name
            };
            return View(RoleViewModel);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id is null) return BadRequest(); //400

            var Role = _roleManager.FindByIdAsync(id).Result;
            if (Role is null) return NotFound(); //404

            var RoleViewModel = new RoleViewModel()
            {
                Id = Role.Id,
                RoleName = Role.Name
            };
            return View(RoleViewModel);
        }
       
        [HttpPost]
        public IActionResult Edit([FromRoute] string? id, RoleViewModel roleViewModel)
        {
            if (id is null) return BadRequest();
            var Message = string.Empty;
            if (ModelState.IsValid) //return View(employeeDto);
            {
                try
                {
                    var role = _roleManager.FindByIdAsync(id).Result;
                    if (role is null) return NotFound();

                    role.Name = roleViewModel.RoleName;

                    var Result = _roleManager.UpdateAsync(role).Result;

                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        Message = "Role can not be updated";
                    //return View(employeeDto);    
                }
                catch (Exception ex)
                {
                    Message = _environment.IsDevelopment() ? ex.Message : "User can not be updated";
                }

            }
            return View(roleViewModel);

        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id is null) return BadRequest(); //400

            var role =  await _roleManager.FindByIdAsync(id);
            if (role is null) return NotFound(); //404

            var roleViewModel = new RoleViewModel()
            {
               Id = id,
               RoleName = role.Name
            };
            return View(roleViewModel);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(string id)
        {
            var role = _roleManager.FindByIdAsync(id).Result;
            var Message = string.Empty;
            try
            {
                if (role is not null)
                {
                    var result = _roleManager.DeleteAsync(role).Result;
                    return RedirectToAction(nameof(Index));
                }
                Message = "An Error happend while deleting the role";
            }

            catch (Exception ex)
            {
                Message = _environment.IsDevelopment() ? ex.Message : "Role can not be updated";
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(nameof(Index));
        }




        #endregion
    }
}
