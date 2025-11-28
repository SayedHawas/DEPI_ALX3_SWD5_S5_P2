using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models
{
    public class ApplicationUser : IdentityUser //GUID As String
    {
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }
    }
}
