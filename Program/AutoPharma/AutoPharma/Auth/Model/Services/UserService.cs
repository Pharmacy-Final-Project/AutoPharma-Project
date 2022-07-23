
using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;

using FastMarket.Auth.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Services
{
    public class UserService : IUserService
    {
        
        private UserManager<ApplicationUser> _userManager;
  
        private SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInMngr)
        {
           
            _userManager = userManager;
            _signInManager = SignInMngr;
        }
        // implementation for the regester method
        public async Task<UserDTO> Register(RegisterUserDTO registerDto, ModelStateDictionary modelstate)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                
                return new UserDTO
                {
                    Username = user.UserName,
                };
            }
          // error list
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? "Password Issue" :
                    error.Code.Contains("Email") ? "Email Issue" :
                    error.Code.Contains("UserName") ? nameof(registerDto.Username) :
                    "";

                modelstate.AddModelError(errorKey, error.Description);
            }
            return null;

        }
        // implementation for the log in method

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
        // method to get all users in our system
        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Username = user.UserName
            };
        }
        // logout from the site
        public async Task Logout()
        {
             await _signInManager.SignOutAsync();
        }

        public async Task<List<ApplicationUser>> getAll()
        {
             return  await _userManager.Users.ToListAsync();
        }
    }
}
