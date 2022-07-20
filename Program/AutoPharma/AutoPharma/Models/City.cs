using System.Collections.Generic;

namespace AutoPharma.Models
{
    public class City
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }

        // Referances
        public List<Branch> Branches { get; set; }
    }
}
