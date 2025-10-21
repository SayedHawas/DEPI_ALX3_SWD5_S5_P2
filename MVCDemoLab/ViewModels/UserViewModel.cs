using System.ComponentModel.DataAnnotations;

namespace MVCDemoLab.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please Enter UserName ")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password ")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
