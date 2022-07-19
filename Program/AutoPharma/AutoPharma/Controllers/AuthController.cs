using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutoPharma.Controllers
{
    public class AuthController : Controller
    {
        private readonly IPharmacist _pharmacist;

        public AuthController(IPharmacist pharmacist)
        {
            _pharmacist = pharmacist;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Will be called by the pharmacist to log into the system
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            //needs error handling

            await _pharmacist.Authenticate(loginDTO.Username, loginDTO.Password);


            return Redirect("/Home/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _pharmacist.Logout();
            return Redirect("Home/Index");
        }
    }
}
