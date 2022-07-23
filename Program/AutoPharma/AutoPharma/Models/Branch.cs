using AutoPharma.Auth.Model;
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
        //public City City { get; set; }
        public List<BranchMedicine> BranchMedicines { get; set; }

        public List<ApplicationUser> Pharmacists { get; set; }
    }
}
