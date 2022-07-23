using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model
{
    public class PharmacistUser : ApplicationUser
    {
       

        /// <summary>
        /// We will use this to determine which branch the pharmacist work in, or what branch he can edit/manage
        /// </summary>
        public int BranchId { get; set; }

        public int CityId { get; set; }

        

    }
}
