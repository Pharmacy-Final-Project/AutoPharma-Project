using System;
using System.Collections.Generic;

namespace AutoPharma.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public string ImageUri { get; set; }
        public DateTime ExpiredDate { get; set; }

        //MOH: Ministry of Health
        public double MOHPrice { get; set; }
        public string Information { get; set; }

    }
}
