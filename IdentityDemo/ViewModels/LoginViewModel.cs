using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Must Enter username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Must Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }  // This property will be used to track the "Remember Me" checkbox
    }
}
