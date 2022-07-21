using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Models
{
    public class City
    {
        //Properties
        public int Id { get; set; }

        [Display(Name ="City")]
        public string Name { get; set; }

        // Referances
        public List<Branch> Branches { get; set; }
    }
}
