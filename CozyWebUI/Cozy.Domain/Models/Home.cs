using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Home
    {

        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ImgURL { get; set; }

        // Foreign key (FK) 
        public string LandlordId { get; set; }
        // Navigation reference
        public Landlord Landlord { get; set; } 

    }
}
