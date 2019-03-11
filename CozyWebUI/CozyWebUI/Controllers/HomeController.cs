using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cozy.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Cozy.Domain.Models;
using CozyWebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CozyWebUI.Controllers
{
    [Authorize(Roles = "Landlord")]
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _environment;

        //constructor
        public HomeController(IHomeService homeService, 
            UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            _homeService = homeService; // dependancy injection
            _userManager = userManager;
            _environment = environment;
        }

        public IActionResult List()
        {
            var landlordId = _userManager.GetUserId(User);
            var homes = _homeService.GetHomesByLandlordId(landlordId);
            


            return View(homes); //ICollection<Home>
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CreateHomeViewModel vm)
        {
            var newHome = vm.Home;
            IFormFile image = vm.Image;

            //upload image
            if (image != null && image.Length > 0)
            {
                string storageFolder = Path.Combine(_environment.WebRootPath,"img/homes");
                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                string fullPath = Path.Combine(storageFolder, newImageName);

                using(var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                //append img location to new home
                newHome.ImgURL = $"/img/homes/{newImageName}";
            }
            // add rightful owner
            newHome.LandlordId = _userManager.GetUserId(User);

            //save new home
            _homeService.Create(newHome);

            return RedirectToAction("List");
        }
    }
}