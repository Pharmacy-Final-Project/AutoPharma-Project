using AutoPharma.Auth.Model;
using AutoPharma.Auth.Model.DTO;
using System.Collections.Generic;

namespace AutoPharma.Models
{
    public class Branch
    {
        //Properties
        public int Id { get; set; }
        public int CityId { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        //References
        
        public List<BranchMedicine> BranchMedicines { get; set; }

        public List<PharmacistUser> Pharmacists { get; set; }
    }
}
