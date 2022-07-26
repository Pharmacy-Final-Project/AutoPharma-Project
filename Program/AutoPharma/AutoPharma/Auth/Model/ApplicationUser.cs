using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model
{
    public class ApplicationUser : IdentityUser
    {
        // For pharmacist user
        [Display(Name = "Full Name")]

        public string FullName { get; set; }
        public int? BranchId { get; set; }

        public int? CityId { get; set; }

        

    }
}
