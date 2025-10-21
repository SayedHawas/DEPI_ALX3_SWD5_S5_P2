using System.ComponentModel.DataAnnotations;

namespace MVCDemoLab.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter UserName ")]
        [MaxLength(100)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password ")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Email ")]
        [MaxLength(150)]
        [DataType(DataType.Password)]
        public string Email { get; set; }
    }
}
