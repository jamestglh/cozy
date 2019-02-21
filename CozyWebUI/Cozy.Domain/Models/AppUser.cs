using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class AppUser : IdentityUser
    {
        //no distinction between landlord and tenant
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Income { get; set; }

        //navigation props
        public ICollection<Home> Homes { get; set; } //landlord only
        public ICollection<Lease> Leases { get; set; } //tenant only
        public ICollection<Maintenance> Maintenances { get; set; } //tenant only

    }
}