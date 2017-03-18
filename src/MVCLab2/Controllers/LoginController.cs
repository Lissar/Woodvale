using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCLab2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCLab2.Controllers
{
    public class LoginController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public LoginController(UserManager<User> usrMgr, SignInManager<User> sim)
        {
            userManager = usrMgr;
            signInManager = sim;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = vm.UserName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                            await signInManager.PasswordSignInAsync(
                                user, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName),
                    "Invalid user or password");
            }
            return View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = vm.UserName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);
                

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
