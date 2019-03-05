using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Cozy.Domain.Models;

namespace CozyWebUI.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        
        //constructor
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService; // dependancy injection
           
        }

        public IActionResult Index()
        {
            var home = _homeService.GetById(1);
             
            return View(home);
        }
    }
}