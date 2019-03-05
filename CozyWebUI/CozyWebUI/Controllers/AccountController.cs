using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using CozyWebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CozyWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _roles = _roleManager.Roles.ToList();  //call role table
        }
        [HttpGet]
        public IActionResult Register()
        {
            //populate roles before rendering view
            var vm = new RegisterViewModel
            {
                Roles = new SelectList(_roles)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //register the user
                var newUser = new AppUser
                {
                    Email = vm.Email,
                    UserName = vm.Email,
                };
                var result = await _userManager.CreateAsync(newUser, vm.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, vm.Role); //apply roles to user

                    await _signInManager.SignInAsync(newUser, true); //lets try to log the user in right away
                    return RedirectToAction("Index", "Home"); //default to current controller
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }

            vm.Roles = new SelectList(_roles);

            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel vm)
        {
            if (ModelState.IsValid)
            {
               var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if (result.Succeeded)
                {
                    // get user
                    var user = await _userManager.FindByEmailAsync(vm.Email);
                    //identify role
                    bool isLandlord = await _userManager.IsInRoleAsync(user, "Landlord");
                    //redirect to right controller based on role
                    if (isLandlord)
                    {
                        return RedirectToAction("Index", "Landlord");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Tenant");
                    }
                }
                else
                {
                    ModelState.AddModelError("SignIn", "Username or Password is Wrong");
                }
            }

            return View(vm);
        }

        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}