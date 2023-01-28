using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paterna.Areas.Manage.ViewModels;
using Paterna.Models;

namespace Paterna.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminVm)
        {
            //if (!ModelState.IsValid) return View();
            AppUser appUser = await _userManager.FindByNameAsync(adminVm.Username);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Username or password invalid");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(appUser, adminVm.Password, false, false);
            if (!result.Succeeded)
            {

                ModelState.AddModelError("", "Username or password invalid");
                return View();
            }

            return RedirectToAction("index", "dashboard");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
