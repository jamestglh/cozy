﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cozy.Domain.Models
{
    public class Lease
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MyProperty { get; set; }
        public double RentPrice { get; set; }

        public int HomeId { get; set; }
        public Home Home { get; set; }

        public string TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
