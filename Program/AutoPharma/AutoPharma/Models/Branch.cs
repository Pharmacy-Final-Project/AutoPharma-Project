﻿using System.Collections.Generic;

namespace AutoPharma.Models
{
    public class Branch
    {
        //Properties
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        

        //References
        public List<BranchMedicine> BranchMedicines { get; set; }

        //public List<Pharmacist> Pharmacists { get; set; }
    }
}