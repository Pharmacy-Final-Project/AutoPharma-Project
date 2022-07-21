using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model.DTO;
using AutoPharma.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Controllers
{
    public class AuthController : Controller
    {
        private readonly IPharmacist _pharmacist;
        private readonly AppDbContext _context;

        public AuthController(IPharmacist pharmacist, AppDbContext context)
        {
            _pharmacist = pharmacist;
            _context = context;
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
          
            return RedirectToAction("Index", "Home");
        }
        public IActionResult SignUp()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address");


            return View();
        }

        
        [HttpPost]
        public async Task<ActionResult<UserDTO>> SignUp(RegisterDTO register)
        {

            

            var user = await _pharmacist.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                //await _pharmacist.Authenticate(register.Username, register.Password);
                return Redirect("/Home/Index");

            }
            else
            {
                return View(register);

            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", register.CityId);

            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address", register.BranchId);

        }
    }
}
