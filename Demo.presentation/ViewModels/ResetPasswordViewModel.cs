using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
