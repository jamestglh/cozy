using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CozyWebUI.ViewModels
{
    public class CreateHomeViewModel
    {
        public Home Home { get; set; }
        public IFormFile Image { get; set; }
    }
}
