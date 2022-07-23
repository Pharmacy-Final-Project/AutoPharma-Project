using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model.DTO;
using AutoPharma.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPharma.Controllers
{
    public class AuthPharmacistController : Controller
    {
        private readonly IPharmacist _pharmacist;
        private readonly AppDbContext _context;

        public AuthPharmacistController(IPharmacist pharmacist, AppDbContext context)
        {
            _pharmacist = pharmacist;
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }
       // [Authorize(Roles = "User")]
        public async Task<ActionResult<PharmacistUserDTO>> Login(LoginDTO loginDTO)
        {
            //needs error handling

            await _pharmacist.Authenticate(loginDTO.Username, loginDTO.Password);


            return Redirect("/Home/Index");
        }
        //[Authorize(Roles = "User")]

        public async Task<IActionResult> Logout()
        {
            await _pharmacist.Logout();
          
            return RedirectToAction("Index", "Home");
        }
        //[Authorize(Roles = "User")]

        public IActionResult RegisterComplete()
        {
            return View();
        }
        //[Authorize(Roles = "User")]

        public IActionResult SignUp()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");

            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address");


            return View();
        }

        //[Authorize(Roles = "User")]

        [HttpPost]
        public async Task<ActionResult<PharmacistUserDTO>> SignUp(RegisterPharmacistDTO register)
        {

            

            var user = await _pharmacist.Register(register, this.ModelState);
            if (ModelState.IsValid)
            {
                //await _pharmacist.Authenticate(register.Username, register.Password);
                return Redirect("/Auth/RegisterComplete");

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
