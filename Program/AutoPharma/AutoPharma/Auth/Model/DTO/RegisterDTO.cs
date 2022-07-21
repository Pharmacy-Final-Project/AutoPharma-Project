using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model.DTO
{
    public class RegisterDTO
    {
        //As an admin, I am registering a pharmacist to a city/branch with email, username & password

        public int Id { get; set; }
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please Enter The Branch Id where the pharmacist will work!")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Please Enter The Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter The Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }

        //Let's try and implement second password verification

        
    }
}
