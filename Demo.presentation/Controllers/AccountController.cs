using Demo.DataAccess.Modules.IdentityModel;
using Demo.presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.presentation.Controllers
{
    public class AccountController (UserManager<ApplicationUser> _userManager): Controller
    {

        #region Register
        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var User = new ApplicationUser()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                UserName = viewModel.UserName,
                Email = viewModel.Email
            };

            var Result = _userManager.CreateAsync(User, viewModel.Password).Result;

            if (Result.Succeeded)
                return RedirectToAction("Login");
            else
            {
                foreach (var error in Result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(viewModel);
            }

        }
        #endregion

        //Login
        //Logout
    }
}
