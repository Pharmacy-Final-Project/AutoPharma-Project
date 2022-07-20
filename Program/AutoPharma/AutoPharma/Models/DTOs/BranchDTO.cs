using System.Collections.Generic;

namespace AutoPharma.Models.DTOs
{
    public class BranchDTO
    {

        public int Id { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //References
        public IEnumerable<BranchMedicine> BranchMedicines { get; set; }

   

        //public List<Pharmacist> Pharmacists { get; set; }
    }
}
