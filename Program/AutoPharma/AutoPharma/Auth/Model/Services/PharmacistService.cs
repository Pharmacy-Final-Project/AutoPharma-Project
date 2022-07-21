using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth
{
    public class PharmacistService : IPharmacist
    {
        private UserManager<PharmacistUser> _userManager;

        private SignInManager<PharmacistUser> _signInManager;

        public PharmacistService(UserManager<PharmacistUser> userManager, SignInManager<PharmacistUser> SignInMngr)
        {

            _userManager = userManager;
            _signInManager = SignInMngr;
        }
        public async Task<UserDTO> Register(RegisterDTO registerDto, ModelStateDictionary modelState)
        {
            var user = new PharmacistUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                CityId = registerDto.CityId,
                BranchId = registerDto.BranchId
                
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                // here goes the roles specifications ... 
                return new UserDTO
                {
                    Username = user.UserName,
                };
            }
            // // Else, that means there is an error, let us collect all the errors using the modelState
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.Username) :
                    "";

                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }
        public async Task<UserDTO> Authenticate(string username, string password)
        {
            // check and map password and user name to log in
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                // if log in succeed then return the user name
                var user = await _userManager.FindByNameAsync(username);
                return new UserDTO
                {
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<UserDTO> GetPharmacist(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Username = user.UserName
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        //public async Task<List<PharmacistUser>> GetAllPharmacists()
        //{
        //    return await _userManager.Users.ToListAsync();
        //}
    }
}
