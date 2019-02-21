using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;

namespace CozyWebUI.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
 


        //constructor
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            
            var home = _homeService.GetById(1);
             
            return View(home);
        }
    }
}