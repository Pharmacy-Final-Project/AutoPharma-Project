using System.Collections.Generic;

namespace AutoPharma.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        //MOH: Ministry of Health
        public double MOHPrice { get; set; }
        public string Information { get; set; }
        

    }
}
