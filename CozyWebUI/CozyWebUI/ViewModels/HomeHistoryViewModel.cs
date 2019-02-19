﻿using Cozy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozyWebUI.ViewModels
{
    public class HomeHistoryViewModel
    {
        public Home Home { get; set; }
        public ICollection<Lease> Leases { get; set; }
    }
}
