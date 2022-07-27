using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoPharma.Auth.Interfaces
{
    public interface IUser
    {
        // These functions will be called by the pharmasist himself
        public Task<PharmacistUserDTO> Authenticate(string username, string password);
        public Task Logout();

        // These functions will be called by the admin to manage pharmacists
        public Task<PharmacistUserDTO> Register(PharmacistRegisterDTO registerData, ModelStateDictionary modelState);


        // ??????????????????????????????????????????????????????????
        public Task<PharmacistUserDTO> GetPharmacist(ClaimsPrincipal principal);
       


        // CRUD
        public Task<List<PharmacistUserDTO>> GetAllPharmacists();
        public Task RemovePharmacist(string id);
        public Task<PharmacistUserDTO> UpdatePharmacist(string id, PharmacistUserDTO user);

        public Task<PharmacistUserDTO> GetPharmacist(string id);




    }
}
