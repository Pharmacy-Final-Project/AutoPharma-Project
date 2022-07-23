using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth.Interfaces
{
    public interface IPharmacist
    {
        // These functions will be called by the pharmasist himself
        public Task<PharmacistUserDTO> Authenticate(string username, string password);
        public Task Logout();

        // These functions will be called by the admin to manage pharmacists
        public Task<PharmacistUserDTO> Register(RegisterPharmacistDTO registerData, ModelStateDictionary modelState);

        public Task<PharmacistUserDTO> GetPharmacist(ClaimsPrincipal principal);

        // We will implement these later
        //public Task<List<PharmacistUser>> GetAllPharmacists();
        //public Task<UserDTO> RemovePharmacist();
        //public Task<UserDTO> MovePharmacistToNewBranch(int cityId, int branchId); //maybe here we need to pass the pharmacist object too



    }
}
