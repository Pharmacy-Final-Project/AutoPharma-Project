using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model.DTO
{
    public class UserRegisterDTO
    {
       
        [Required(ErrorMessage = "Please Enter The Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter The Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }
    }
}
