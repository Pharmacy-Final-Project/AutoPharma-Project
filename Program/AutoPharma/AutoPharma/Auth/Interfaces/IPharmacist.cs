using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth.Interfaces
{
    public interface IPharmacist
    {
        // These functions will be called by the pharmasist himself
        public Task<UserDTO> Authenticate(string username, string password);
        public Task Logout();

        // These functions will be called by the admin to manage pharmacists
        public Task<UserDTO> Register(RegisterDTO registerData, ModelStateDictionary modelState);

        public Task<UserDTO> GetPharmacist(ClaimsPrincipal principal);

        // We will implement these later
        //public Task<UserDTO> GetAllPharmacists();
        //public Task<UserDTO> RemovePharmacist();
        //public Task<UserDTO> MovePharmacistToNewBranch(int cityId, int branchId); //maybe here we need to pass the pharmacist object too



    }
}
