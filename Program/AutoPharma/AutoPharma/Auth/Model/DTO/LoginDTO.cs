using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Auth.Model.DTO
{
    public class LoginDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password!")]
        public string Password { get; set; }

    }

    
}
