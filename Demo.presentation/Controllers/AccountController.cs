using System.Security.Cryptography.X509Certificates;
using Demo.DataAccess.Modules.IdentityModel;
using Demo.presentation.Utilities;
using Demo.presentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.presentation.Controllers
{
    public class AccountController (UserManager<ApplicationUser> _userManager,
                                    SignInManager<ApplicationUser> _signInManager): Controller
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
                return RedirectToAction("Login", "Account");
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

        #region Login
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public  IActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user =  _userManager.FindByEmailAsync(viewModel.Email).Result;

                if(user is not null)
                {
                    var password =  _userManager.CheckPasswordAsync(user, viewModel.Password).Result;

                    if(password)
                    {

                        var Result =  _signInManager.PasswordSignInAsync(user,viewModel.Password,viewModel.RememberMe,false).Result;

                        if (Result.Succeeded)
                            return RedirectToAction("Index", "Home");
                        
                    }
                    else
                        ModelState.AddModelError(string.Empty, "Password is wrong");
                    
                }

                else
                    ModelState.AddModelError(string.Empty, "Email is not found");
                
            }

            return View(viewModel);
           
        }
        #endregion

        #region LogOut
        public new IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region Forget Password
        [HttpGet]
        public IActionResult ForgetPassword() => View();

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPassword viewModel)
        {
            if (ModelState.IsValid)
            {
                var User = _userManager.FindByEmailAsync(viewModel.Email).Result;

                if(User is not null)
                {

                    var Token = _userManager.GeneratePasswordResetTokenAsync(User).Result;

                    var ResetPasswordLink = Url.Action("ResetPassword", "Account", new { email = viewModel.Email, Token}, Request.Scheme );
                    var email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",
                        Body = ResetPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CheckYourInbox");
                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(nameof(ForgetPassword), viewModel);
        }
        #endregion

        #region CheckYourInbox
        [HttpGet]
        public IActionResult CheckYourInbox() => View();
        #endregion

        #region Resetpassword
        [HttpGet]
        public IActionResult ResetPassword(string Email, string Token)
        {
            TempData["email"] = Email;
            TempData["token"] = Token;

            return View();
        }
        //Pa$$w0rd
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetViewModel)
        {
            if (!ModelState.IsValid) return View(resetViewModel);

            string email = TempData["email"] as string ?? string.Empty;
            string Token = TempData["token"] as string ?? string.Empty;

            var User = _userManager.FindByEmailAsync(email).Result;
            if(User is not null)
            {
                var Result = _userManager.ResetPasswordAsync(User, Token, resetViewModel.Password).Result;

                if (Result.Succeeded)
                    return RedirectToAction(nameof(Login));
                else
                {
                    foreach (var error in Result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(nameof(ResetPassword), resetViewModel);
        }
        #endregion
    }
}
