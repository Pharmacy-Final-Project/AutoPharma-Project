
using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FastMarket.Auth.Models.Interfaces
{
    // this is an interface for the User Identity
    public interface IUserService
    {

        //Register Method
        public Task<UserDTO> Register(RegisterUserDTO registerUserDTO, ModelStateDictionary modelstate);
        //login Method

        public Task<UserDTO> Authenticate(string username, string password);
        // Get All users method
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
        // logout method
        public Task Logout();
        public Task<List<ApplicationUser>> getAll();


    }
}
