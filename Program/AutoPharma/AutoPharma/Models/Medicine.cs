using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPharma.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public string ImageUri { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime ExpiredDate { get; set; }

        //MOH: Ministry of Health
        public double MOHPrice { get; set; }
        public string Information { get; set; }

    }
}
