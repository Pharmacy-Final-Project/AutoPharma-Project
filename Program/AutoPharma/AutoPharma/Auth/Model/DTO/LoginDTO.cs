using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="Please Enter Your Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password!")]
        public string Password { get; set; }

    }

    
}
