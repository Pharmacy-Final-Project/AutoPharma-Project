using AutoPharma.Auth.Interfaces;
using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth
{
    public class PharmacistService : IPharmacist
    {
        public Task<UserDTO> Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> GetPharmacist(ClaimsPrincipal principal)
        {
            throw new System.NotImplementedException();
        }

        public Task Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> Register(RegisterDTO registerData, ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }
    }
}
