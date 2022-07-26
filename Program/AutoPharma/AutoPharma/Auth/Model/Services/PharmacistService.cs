using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;
using AutoPharma.Data;
using AutoPharma.Data.Static;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth
{
    public class PharmacistService : IUser
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        private readonly AppDbContext _context;

        public PharmacistService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = SignInMngr;
        }
        public async Task<PharmacistUserDTO> Register(PharmacistRegisterDTO registerDto, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                FullName=registerDto.FullName,
                UserName = registerDto.Username,
                Email = registerDto.Email,
                CityId = registerDto.CityId,
                BranchId = registerDto.BranchId
                
            };
            // this line is to add this registersd user to the editor(pharmacist) Role
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Editor);

                // here goes the roles specifications ... 
                return new PharmacistUserDTO
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

        public async Task<PharmacistUserDTO> GetPharmacist(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new PharmacistUserDTO
            {
                Username = user.UserName,
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<PharmacistUserDTO>> GetAllPharmacists()
        {
            //users from users database
            var users = await _userManager.Users.ToListAsync();

            //I return a List<PharmacistUserDTO>, so i need to iterate previous list and create a new list

            List<PharmacistUserDTO> userDTOs = new List<PharmacistUserDTO>();

            foreach (var item in users)
            {
                userDTOs.Add(new PharmacistUserDTO
                {
                    Id = item.Id,
                    CityId = item.CityId,
                    BranchId = item.BranchId,
                    Username = item.UserName
                    //FULL NAME!

                }
                );
                
            }

            return userDTOs;
        }

        public async Task RemovePharmacist(string id)
        {
            string convertedId = id;

            var user = await _userManager.Users
               .Where(x => x.Id == convertedId)
               .FirstOrDefaultAsync();

            await _userManager.DeleteAsync(user);
        }


        public async Task<PharmacistUserDTO> UpdatePharmacist(string id, PharmacistUserDTO user)
        {
            //1- update it
            //2- return it
            string convertedId = Convert.ToString(id);

            var appUser = await _userManager.FindByIdAsync(convertedId);
            appUser.CityId = user.CityId;
            appUser.BranchId = user.BranchId;
            appUser.UserName = user.Username;

            var returnedUserDto = new PharmacistUserDTO
            {
                Id = appUser.Id,
                BranchId = appUser.BranchId,
                CityId = appUser.CityId,
                Username = appUser.UserName
            };

            var result = await _userManager.UpdateAsync(appUser);

            return returnedUserDto;
        }

        public async Task<PharmacistUserDTO> GetPharmacist(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var returnDto = new PharmacistUserDTO
            {
                Id = user.Id,
                BranchId = user.BranchId,
                CityId = user.CityId,
                Username = user.UserName
            };

            return returnDto;
        }
    }
}
