using Cozy.Domain.Models;
using Cozy.Service.Services;
using CozyWebUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozyWebUI.Controllers
{
    [Authorize(Roles = "Landlord")]
    public class LandlordController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILeaseService _leaseService;

        public LandlordController(IHomeService homeService, ILeaseService leaseService)
        {
            _homeService = homeService;
            _leaseService = leaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeHistory(int id)
        {
            HomeHistoryViewModel vm = new HomeHistoryViewModel();

            vm.Home = _homeService.GetById(id);
            vm.Leases = _leaseService.GetByHomeId(id);

            return View(vm);
        }
    }
}
