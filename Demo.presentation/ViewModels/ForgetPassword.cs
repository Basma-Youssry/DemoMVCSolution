using System.ComponentModel.DataAnnotations;

namespace Demo.presentation.ViewModels
{
    public class ForgetPassword
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
    }
}
