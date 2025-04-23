using Demo.BusinessLogic.DataTransfareObject.EmployeesDto;
using Demo.DataAccess.Modules.EmployeeModel;
using Demo.DataAccess.Modules.IdentityModel;
using Demo.DataAccess.Modules.Shared.Enums;
using Demo.presentation.ViewModels.EmployeeViewModel;
using Demo.presentation.ViewModels.UsersViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.presentation.Controllers
{
    public class UserController(UserManager<ApplicationUser> _userManager,
                                  ILogger<EmployeeController> _logger,
                                  IWebHostEnvironment _environment) : Controller
    {
        #region Index
        //Get All Users
        [HttpGet]
        public IActionResult Index(string searchValue)
        {
            var usersQuery = _userManager.Users.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
                
                usersQuery = usersQuery.Where(U => U.UserName.ToLower().Contains(searchValue.ToLower()));

            var usersList = usersQuery.Select(
                U => new UserViewModel
                {
                    Id = U.Id,
                    FName = U.FirstName,
                    LName = U.LastName,
                    Email = U.Email,
                    PhoneNumber = U.PhoneNumber
                });

            foreach (var user in usersList)
            {
                user.Roles = _userManager.GetRolesAsync(_userManager.FindByIdAsync(user.Id).Result).Result;
            }

            return View(usersList);
        }

        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(string? id)
        {
            if (id is null) return BadRequest(); //400

            var user = _userManager.FindByIdAsync(id).Result;
            if (user is null) return NotFound(); //404

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Roles = _userManager.GetRolesAsync(user).Result
            };
            return View(userViewModel);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id is null) return BadRequest();

            var user = await _userManager.FindByIdAsync(id);

            if (user is null) return NotFound();
            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Roles = _userManager.GetRolesAsync(user).Result
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] string? id, UserViewModel userViewModel)
        {
            if (id is null) return BadRequest();
            var Message = string.Empty;
               if (ModelState.IsValid) //return View(employeeDto);
               {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    if (user is null) return NotFound();

                    user.FirstName = userViewModel.FName;
                    user.LastName = userViewModel.LName;
                    user.Email = userViewModel.Email;
                    user.PhoneNumber = userViewModel.PhoneNumber;
                    user.UserName = userViewModel.UserName;
                    var Result = await _userManager.UpdateAsync(user);

                    if (Result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        Message = "User can not be updated";
                    //return View(employeeDto);    
                }
                catch (Exception ex)
                {
                    Message = _environment.IsDevelopment() ? ex.Message : "User can not be updated";
                }

               }
               return View(userViewModel);

        }

        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id is null) return BadRequest(); //400

            var user = await _userManager.FindByIdAsync(id);
            if (user is null) return NotFound(); //404

            var userViewModel = new UserViewModel()
            {
                Id = user.Id,
                FName = user.FirstName,
                LName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Roles = _userManager.GetRolesAsync(user).Result
            };
            return View(userViewModel);
        }


        [HttpPost] 
        public IActionResult ConfirmDelete(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var Message = string.Empty;
            try
            {
               if(user is not null)
                {
                  var result = _userManager.DeleteAsync(user).Result;
                    return RedirectToAction(nameof(Index));
                }
                Message = "An Error happend while deleting the user";
            }

            catch (Exception ex)
            {
               Message = _environment.IsDevelopment() ? ex.Message : "User can not be updated"; 
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(nameof(Index));
        }




        #endregion
    }
}
