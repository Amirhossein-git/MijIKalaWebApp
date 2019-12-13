using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MijiKalaWebApp.Models.ViewModels;
using MijiKalaWebApp.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using MijiKalaWebApp.Models.DataModels.Person;

namespace WebApplication1.Controllers
{
    public class RegisteryController : Controller
    {
        private UserManager<IdentityUser> _userManger;
        private SignInManager<IdentityUser> _signInManger;
        public RegisteryController(UserManager<IdentityUser> userManger, SignInManager<IdentityUser> signInManger)
        {
            _userManger = userManger;
            _signInManger = signInManger;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(signInViewModel);
            var user = await _userManger.FindByNameAsync(signInViewModel.UserName);
            if (user != null)
            {
                await _signInManger.SignOutAsync();
                var result = await _signInManger.PasswordSignInAsync(user, signInViewModel.PassWord, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                        returnUrl = "/";
                    return Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", ".نام کاربری یا رمز عبور اشتباه است");
            return View(signInViewModel);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Home", "Home", new { signedUp = true });
            return View(signUpViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(PersonViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cart(object obj/*haminjoori gozashtam ke error nade*/)
        {
            return View();
        }

    }
}