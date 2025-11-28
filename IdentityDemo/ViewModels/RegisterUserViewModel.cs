using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.ViewModels
{
    public class RegisterUserViewModel
    {

        [MaxLength(100)]
        [Required(ErrorMessage = "Must Enter UserName")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Must Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Must Re-Enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Match ...")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
    }
}
