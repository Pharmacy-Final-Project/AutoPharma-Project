using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
