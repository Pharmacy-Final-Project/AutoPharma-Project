using AutoPharma.Auth.Model.DTO;
using AutoPharma.Data;
using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoPharma.Controllers
{
    public class AuthUserController : Controller
    {

        private readonly IUserService _IUser;
       

        public AuthUserController(IUserService User)
        {
            _IUser = User;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Admin,Editor")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {


            await _IUser.Authenticate(loginDTO.Username, loginDTO.Password);


            return Redirect("/Home/Index");
        }
       // [Authorize(Roles = "Admin,Editor")]

        public async Task<IActionResult> Logout()
        {
            await _IUser.Logout();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterComplete()
        {
            return View();
        }
        // [Authorize(Roles = "Admin")]

        public IActionResult SignUp()
        {
            return View();
        }
        // [Authorize(Roles = "Admin")]

        // call regester service to sign up then if succeed go to home
        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterUserDTO register)
        {
            var user = await _IUser.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                await _IUser.Authenticate(register.Username, register.Password);
                return Redirect("/Home/Index");

            }
            else
            {
                return View(register);

            }

        }
    }
}



