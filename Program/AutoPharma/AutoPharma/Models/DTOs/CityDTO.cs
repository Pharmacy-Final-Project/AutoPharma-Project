using System.Collections.Generic;

namespace AutoPharma.Models.DTOs
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BranchDTO> Branchs { get; set; }
    }
}
